export interface ModuleModel{
    id: number;
    name: string;
    label: string;
    description: string;
    priority: number;
    isActive: boolean;
    controllers: ControllerModel[];
}
export interface ControllerModel{
    id: number;
    moduleId: number;
    name: string;
    label: string;
    priority: number;
    controllerActions: ControllerActionModel[];
}
export interface ControllerActionModel{
    controllerId: number;
    actionId: number;
}
export interface ActionModel{
    id: number;
    priority: number;
    name: string;
    label: string;
}
