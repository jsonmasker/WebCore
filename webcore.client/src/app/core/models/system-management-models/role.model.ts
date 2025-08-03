export interface RoleModel {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
    selectedRoleClaims: SelectedRoleClaimModel[];
}

export interface SelectedRoleClaimModel {
    id: number;
    roleClaimGroupId: number;
    roleClaimId: number;
}

export interface RoleClaimModel {
    id: number;
    roleClaimGroupId: number;
    name: string;
    description: any;
    // createdOn: string;
    // modifiedOn: string;
    // isDeleted: boolean;
    // isActive: boolean;
    // createdBy: string;
    // modifiedBy: any;
    //selectRoleClaims: SelectedRoleClaimDTO[];
  }
  
  export interface RoleClaimGroupModel {
    id: number;
    moduleId: number;
    name: string;
    description: any;
    //priority: number;
    // createdOn: string;
    // modifiedOn: string;
    // isDeleted: boolean;
    // isActive: boolean;
    // createdBy: string;
    // modifiedBy: any;
    roleClaims: RoleClaimModel[];
  }
  
  export interface ModuleModel {
    id: number;
    name: string;
    description: any;
    // priority: number;
    // createdOn: string;
    // modifiedOn: string;
    // isDeleted: boolean;
    // isActive: boolean;
    // createdBy: string;
    // modifiedBy: any;
    roleClaimGroups: RoleClaimGroupModel[];
  }
  