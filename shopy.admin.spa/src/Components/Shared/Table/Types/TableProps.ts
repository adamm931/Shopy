import { TableColumnProps } from './TableColumnProps';

export interface TableProps {
    Title: string,
    AddItemUrl: string,
    Header: TableColumnProps[],
    ActionsCount: number,
    RenderBody: () => JSX.Element[] | null
}