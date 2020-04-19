import { IKeyValue } from './../../Components/Shared/Types/IKeyValue';

export class Header {

    private values: IKeyValue[]

    constructor() {
        this.values = []
    }

    public AddEntry = (key: string, value: string): void => {
        this.values.push({
            Key: key,
            Value: value
        })
    }

    public Raw = (): any => {
        let raw: { [key: string]: string } = {};

        this.values.forEach(entry => {
            raw[entry.Key] = entry.Value
        });

        return raw
    }
}