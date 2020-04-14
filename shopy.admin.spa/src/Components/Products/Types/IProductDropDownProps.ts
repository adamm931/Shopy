import { IKeyValue } from './../../Shared/Types/IKeyValue';

export interface IProductDropDownProps {
    Name: string;
    Multiple?: boolean;
    Items: IKeyValue[];
    SelectedItem?: string;
    SelectedItems?: string[];
    OnChange: (event: React.ChangeEvent<HTMLSelectElement>) => void;
}