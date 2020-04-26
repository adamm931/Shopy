import { history } from './../State/ShopyStore';

export class HistoryUtils {

    public static Redirect(path: string): void {
        history.push(path);
    }
}