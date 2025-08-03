using System.ComponentModel.DataAnnotations;

namespace Common
{
    //client content key

   
    public enum EUserAction
    {
        View,
        ViewDetails,
        Create,
        Update,
        SoftDalete,
        Restore,
        Delete,
        Export,
        Import,
        LogIn,
        LogOut
    }
    public enum EUserActionStatus
    {
        Successful,
        Failed
    }

    public enum EModules
    {
        Lipstick,
        SlideShow,
        Feature,
    }
    public enum EFolderNames
    {
        Blogs,
        HomeBanners,
        Brands,
        Products,
        Categories,
        Sliders,
        Users,
        Orders,
        Settings,
        Pages,
        System,
        Topics,
        Images,
        Videos,
        ReportFiles,
        QRCodes,
        PageIntros,
    }
    public enum EActions
    {
        View,
        Create,
        Update,
        SoftDelete,
        Restore,
        Delete,
        Export,
        Import
    }
    public enum EStatusCodes
    {
        Success = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        Locked = 423,
        InternalServerError = 500
    }
    
    public enum ELanguages
    {
        EN,
        VN
    }
 
    public enum EQRCodeTypes
    {
        Number,
        Character,
        CharacterAndNumber,
    }
    public enum ERoles
    {
        Admin,
        User,
        Guest
    }

}
