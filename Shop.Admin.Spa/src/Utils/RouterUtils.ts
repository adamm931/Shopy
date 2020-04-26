import { RouteComponentProps } from 'react-router-dom';

export class RouteUtils {
    public static GetIdParam = (route: RouteComponentProps): string => {
        let entry = Object.entries(route.match.params).find(e => e[0] === 'id')

        if (entry == undefined) {
            return '';
        }

        return entry[1] as string
    }
}