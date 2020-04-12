import { createBrowserHistory } from 'history'

export class HistoryUtils {

    public static Redirect(path: string): void {
        let history = createBrowserHistory();
        history.push(path);
    }
}