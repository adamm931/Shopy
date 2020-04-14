import { IKeyValue } from './IKeyValue';

export interface IDropDownProps {
    Items: IKeyValue[];
    Name: string;
    ClassName?: string;
    SelectedItem?: string;
    SelectedItems?: string[];
    Multiple?: boolean;
    OnChange: (event: React.ChangeEvent<HTMLSelectElement>) => void;
}