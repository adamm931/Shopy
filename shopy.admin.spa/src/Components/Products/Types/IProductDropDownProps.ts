import { IKeyValue } from './../../Shared/Types/IKeyValue';

export interface IProductDropDownProps {
    Name: string;
    Multiple?: boolean;
    Items: IKeyValue[];
    OnChange: (event: React.ChangeEvent<HTMLSelectElement>) => void;
}