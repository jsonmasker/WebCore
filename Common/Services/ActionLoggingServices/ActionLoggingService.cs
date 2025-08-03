using Common.Models;
using Common.Services.JwtServices;
using Microsoft.Extensions.Options;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace Common.Services.ActionLoggingServices
{
    public class ActionLoggingService : IActionloggingService
    {
        private readonly IMongoCollection<UserActionModel> _userActionsCollection;
        private readonly IJwtService _jwtService;
        public ActionLoggingService(
            IJwtService jwtService,
            IOptions<UserActionLoggingDatabaseSettings> userActionDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                userActionDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                userActionDatabaseSettings.Value.DatabaseName);
            _userActionsCollection = mongoDatabase.GetCollection<UserActionModel>(
                userActionDatabaseSettings.Value.UserActionsCollectionName);
            _jwtService = jwtService;
        }

        public async Task<Pagination<UserActionModel>> GetAllAsync(string? controllerName, string? actionName, DateTime? startDate, DateTime? endDate, int pageIndex, int pageSize)
        {
            Pagination<UserActionModel> result = new Pagination<UserActionModel>();
            if(pageSize > 0)
                result.PageSize = pageSize;
            var filterBuilder = Builders<UserActionModel>.Filter;
            var filter = filterBuilder.Empty;
            if (!string.IsNullOrEmpty(controllerName) && controllerName != "-1")
            {
                filter &= filterBuilder.Eq(s => s.ControllerName, controllerName);
            }

            if (!string.IsNullOrEmpty(actionName) && actionName != "-1")
            {
                filter &= filterBuilder.Eq(s => s.ActionName, actionName);
            }

            if (startDate != null)
            {
                filter &= filterBuilder.Gte(s => s.CreatedDate, startDate.Value.Date);
            }

            if (endDate != null)
            {
                filter &= filterBuilder.Lte(s => s.CreatedDate, endDate.Value.Date.AddDays(1));
            }

            var userActions = await _userActionsCollection.Find(filter).Sort(Builders<UserActionModel>.Sort.Descending("CreatedDate")).ToListAsync();
            result.TotalItems = userActions.Count;
            result.PageIndex = pageIndex;
            result.TotalPages = (int)Math.Ceiling(result.TotalItems / (double)result.PageSize);
            result.CurrentPage = result.PageIndex;
            result.Items = userActions.Skip((result.CurrentPage - 1) * result.PageSize).Take(result.PageSize);
            return result;
        }

        public async Task<UserActionModel> GetAsync(string id) =>
            await _userActionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserActionModel userAction) =>
            await _userActionsCollection.InsertOneAsync(userAction);

        public async Task CreateAsync(string token, string controllerName, Enum action, Enum actionStatus, object? obj = null )
        {
            try
            {
                UserActionModel userAction = new UserActionModel()
                {
                    ControllerName = controllerName,
                    ActionName = action.ToString(),
                    Status = actionStatus.ToString(),
                    UserId = _jwtService.GetUserIdFromToken(token),
                    UserName = _jwtService.GetUserNameFromToken(token),
                    Details = obj == null ? "" : Newtonsoft.Json.JsonConvert.SerializeObject(obj),
                };

                await _userActionsCollection.InsertOneAsync(userAction);
            }catch(Exception ex)
            {
                throw (ex);
            }

        }

        //public async Task UpdateAsync(string id, UserAction updatedBook) =>
        //    await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        //public async Task RemoveAsync(string id) =>
        //    await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
