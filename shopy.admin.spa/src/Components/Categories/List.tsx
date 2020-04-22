import React from 'react'
import { CategoryListProps } from './Types/CategoryListProps'
import { connect } from 'react-redux'
import { CategoryListItem } from './ListItem'

class CategoriesList extends React.Component<CategoryListProps> {

    componentDidMount() {
        // calling dipatch here
    }

    render() {
        return <div className="table-responsive">
            <table className="table table-striped table-sm">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Caption</th>
                        <th colSpan={2}>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {Props.Items.map((category, index) =>
                        <CategoryListItem key={index} {...category} Index={index} />)}
                </tbody>
            </table>
        </div>
    }
}


const Props: CategoryListProps = {
    Items: [{
        Index: 0,
        Uid: '12312asdasdas',
        Name: 'Shoes'
    },
    {
        Index: 1,
        Uid: '1234453453453',
        Name: 'Jackets'
    },
    {
        Index: 2,
        Uid: 'asdaasrty45645645',
        Name: 'TShirts'
    }, {
        Index: 3,
        Uid: 'asdasd657857kghjg',
        Name: 'Footweat'
    }]
}

export default connect()(CategoriesList)