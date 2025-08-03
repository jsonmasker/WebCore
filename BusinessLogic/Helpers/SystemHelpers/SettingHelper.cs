using AutoMapper;
using BusinessLogic.IHelpers.ISystemHelpers;
using Common.ViewModels.SystemViewModels;
using Newtonsoft.Json;

namespace BusinessLogic.Helpers.SystemHelpers
{
    public class SettingHelper : ISettingHelper
    {
        private readonly IMapper _mapper;
        private const string webConfigurationPath = @".\LocalData\WebConfiguration.json";
        public SettingHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<SettingViewModel> GetAll()
        {
            using StreamReader reader = new(webConfigurationPath);
            string json = reader.ReadToEnd();
            List<SettingViewModel> data = JsonConvert.DeserializeObject<List<SettingViewModel>>(json);
            return data;
        }

        public SettingViewModel GetByKey(string key)
        {
            using StreamReader reader = new(webConfigurationPath);
            string json = reader.ReadToEnd();
            List<SettingViewModel> data = JsonConvert.DeserializeObject<List<SettingViewModel>>(json);
            var model = data.FirstOrDefault(s => s.Key == key);
            if (model == null)
            {
                throw new Exception("Invalid key");
            }
            return model;
        }

        public void Update(SettingViewModel model)
        {
            using StreamReader reader = new(webConfigurationPath);
            string json = reader.ReadToEnd();
            List<SettingViewModel> data = JsonConvert.DeserializeObject<List<SettingViewModel>>(json);
            SettingViewModel webConfig = data.FirstOrDefault(s => s.Key == model.Key);
            if (webConfig == null)
            {
                return;
            }
            webConfig.Value = model.Value;
            string json1 = JsonConvert.SerializeObject(data);
            File.WriteAllText(webConfigurationPath, json1);
        }
    }
}
