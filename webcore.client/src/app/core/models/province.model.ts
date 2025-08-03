export interface ProvinceModel {
    id: number;
    name: string;
    districts: DistrictModel[];
}
export interface DistrictModel {
    id: number;
    name: string;
}