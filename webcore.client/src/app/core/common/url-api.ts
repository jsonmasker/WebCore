export enum EUrl {
    //#region System
    //My Account
    changePasswordUrlMyAccount = "/api/myaccount/changepassword",
    loginUrl = "/api/myaccount/login",
    recoverPasswordUrl = "/api/myaccount/recoverpassword",
    resetPasswordUrl = "/api/myaccount/resetpassword",
    refreshTokenUrl = "/api/myaccount/refreshtoken",
    validateRefreshTokenUrl = "/api/myaccount/validaterefreshtoken",
    reNewToken = "/api/myaccount/renewtoken",
    //province
    getAllUrlProvince = "/api/province/getall",
    //Account
    getAllUrlAccount = "/api/user/getall",
    getByIdUrlAccount = "/api/user/getbyid/",
    createUrlAccount = "/api/user/create",
    updateUrlAccount = "/api/user/update",
    //Role
    getAllUrlRole = "/api/role/getall",
    getAllActiveUrlRole = "/api/role/getallactive",
    getByIdUrlRole = "/api/role/getbyid",
    createUrlRole = "/api/role/create",
    updateUrlRole = "/api/role/update",
    //Module
    getAllUrlModule = "/api/module/getall",
    getByIdUrlModule = "/api/module/getbyid",
    createUrlModule = "/api/module/create",
    updateUrlModule = "/api/module/update",
    //Action
    getAllUrlAction = "/api/action/getall",
    getAllActiveUrlAction = "/api/action/getallactive",
    getEActionUrlAction = "/api/action/geteaction",
    getByIdUrlAction = "/api/action/getbyid",
    createUrlAction = "/api/action/create",
    updateUrlAction = "/api/action/update",
    //Setting
    getAllUrlSetting = "/api/setting/getall",
    getByKeyUrlSetting = "/api/setting/getbykey",
    updateUrlSetting = "/api/setting/update",
    //Action logging
    getAllUrlActionLogging = "/api/actionlogging/getall",
    getByIdUrlActionLogging = "/api/actionlogging/getbyid",
    //#endregion
    //participant
    getAllUrlParticipant = "/api/participant/getall",
    getEagerByIdUrlParticipant = "/api/participant/geteagerbyid",
    exportExcelUrlParticipant = "/api/participant/exportexcel",
    //question
    getAllUrlQuestion = "/api/question/getall",
    getAllByQuestiongroupIdUrlQuestion = "/api/question/getallbyquestiongroupid",
    getByIdUrlQuestion = "/api/question/getbyid",
    createUrlQuestion = "/api/question/create",
    updateUrlQuestion = "/api/question/update",
    softDeleteUrlQuestion = "/api/question/softdelete",
    //questionGroup
    getAllUrlQuestionGroup = "/api/questiongroup/getall",
    getAllActiveUrlQuestionGroup = "/api/questiongroup/getallactive",
    getByIdUrlQuestionGroup = "/api/questiongroup/getbyid",
    getEagerByIdUrlQuestionGroup = "/api/questiongroup/geteagerbyid",
    getEagerAllElementsUrlQuestionGroup = "/api/questiongroup/geteagerallelements",
    createUrlQuestionGroup = "/api/questiongroup/create",
    updateUrlQuestionGroup = "/api/questiongroup/update",
    softDeleteUrlQuestionGroup = "/api/questiongroup/softdelete",
    //questionType
    getAllUrlQuestionType = "/api/questiontype/getall",
    //surveyForm
    getAllUrlSurveyForm = "/api/surveyform/getall",
    getAllActiveUrlSurveyForm = "/api/surveyform/getallactive",
    getByIdUrlSurveyForm = "/api/surveyform/getbyid",
    getEagerByIdUrlSurveyForm = "/api/surveyform/geteagerbyid",
    getEagerUIByIdUrlSurveyForm = "/api/surveyform/geteageruibbyid",
    createUrlSurveyForm = "/api/surveyform/create",
    updateUrlSurveyForm = "/api/surveyform/update",
    softDeleteUrlSurveyForm = "/api/surveyform/softdelete",
    //surveyReport
    
    //#endregion
}