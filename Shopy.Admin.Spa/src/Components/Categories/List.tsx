import React from 'react'
import { connect } from 'react-redux'
import { CategoryListProps } from './Types/CategoryListProps'
import CategoryListItem from './ListItem'
import { CategoryListDispatch } from './Types/CategoryListDispatch'
import { IShopyState } from '../../State/ShopyState'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { Link } from 'react-router-dom'
import { Table } from '../Shared/Table/Table'


class CategoriesList extends React.Component<CategoryListProps & CategoryListDispatch> {

    componentDidMount() {
        this.props.List()
    }

    render() {
        return <Table
            Title="Categories"
            AddItemUrl="categories/add"
            Header={[
                { Name: 'Name' },
            ]}
            ActionsCount={2}
            RenderBody={() => this.props.Categories.map((category, index) =>
                <CategoryListItem
                    key={index}
                    {...category}
                    Index={index}
                />)
            }
        />
    }
}

const mapStateToProps = (state: IShopyState): CategoryListProps => ({
    Categories: state.Categories.map((item, index) => ({
        Index: index,
        Uid: item.Uid,
        Name: item.Name
    }))
})

const mapDisptachToProps = (dispatch: any): CategoryListDispatch => ({
    List: () => dispatch(RequestFactory.ListCategories())
})

export default connect(mapStateToProps, mapDisptachToProps)(CategoriesList)