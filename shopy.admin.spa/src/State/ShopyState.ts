export interface IShopyState {
    IsUserLogged: boolean;
}

export const GetInitailState = () => <IShopyState>{
    IsUserLogged: false
}