import { IKeyValue } from './IKeyValue';

export interface IDropDownProps {
    Items: IKeyValue[];
    Name: string;
    ClassName?: string;
    Multiple?: boolean;
    OnChange: (event: React.ChangeEvent<HTMLSelectElement>) => void;
}