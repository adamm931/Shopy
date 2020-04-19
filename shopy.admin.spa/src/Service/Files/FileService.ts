import { HeaderKeys } from './../../Common/HeaderKeys';
import { IKeyValue } from './../../Components/Shared/Types/IKeyValue';
import { PostForm } from "../Api/ShopyClient"

export class FileService {

    public static Upload = async (file: File, path: string) => {

        let headers: IKeyValue[] = [{
            Key: HeaderKeys.XDestination,
            Value: path
        }]

        let form = new FormData();
        form.append("file", file)

        await PostForm("/files/upload", form, headers)
    }

}