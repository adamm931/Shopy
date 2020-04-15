import React from 'react';
import { IChangeCategoriesProps } from './Types/IChangeProductCategoriesProps'
import { ChangeCategoryItem } from './ChangeCategoryItem'
import { DropDownList } from '../Shared/DropDownList'
import { IChangeCategoriesState } from './Types/IChangeCategoriesState'
import { IChangeCategoriesDispatch } from './Types/IChangeCategoriesDIspatch';
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { connect } from 'react-redux';
import { IShopyState } from '../../State/ShopyState';
import { RouteComponentProps } from 'react-router-dom';
import { RouteUtils } from '../../Utils/RouterUtils';

type Props = IChangeCategoriesProps & IChangeCategoriesDispatch & RouteComponentProps

class ChangeCategories extends React.Component<Props, IChangeCategoriesState> {

    constructor(props: Props) {
        super(props)

        this.state = {
            SelectedCategoryUid: '',
            AvailableCategories: [],
            ProductCategories: [],
            ProductUid: RouteUtils.GetIdParam(props)
        }

        this.props.CategoriesLookup();
        this.props.GetProductCategories();
    }

    componentWillReceiveProps = (newProps: IChangeCategoriesProps) => {

        console.log('componentWillReceiveProps', newProps)

        this.setState({
            ...this.state,
            AvailableCategories: newProps.AvailableCategories,
            ProductCategories: newProps.ProductCategories
        })
    }

    setSelectedCategory = (event: React.ChangeEvent<HTMLSelectElement>) => {
        event.preventDefault();

        console.log('setSelectedCategory', event.target.value)

        this.setState({
            ...this.state,
            SelectedCategoryUid: event.target.value
        })
    }

    addToSelectedCategory = () => {
        let categoryUid = this.state.SelectedCategoryUid;

        if (categoryUid == undefined) {
            return
        }

        if (this.state.ProductCategories.some(productCategory => productCategory.Key == categoryUid)) {
            return
        }

        // last element
        if (this.state.AvailableCategories.length == 1) {
            categoryUid = this.state.AvailableCategories[0].Key
        }

        this.props.AddTo(this.state.ProductUid, categoryUid)
    }

    removeFromCategory = (productUid: string, categoryUid: string) => {
        this.props.RemoveFrom(productUid, categoryUid)
    }

    render() {
        return (
            <React.Fragment>
                <h2>Add or remove categories for product</h2>
                <div className="table-responsive">
                    <table className="table table-striped table-sm">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th colSpan={2}>Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.ProductCategories.map((category, index) =>
                                    <ChangeCategoryItem
                                        Index={index}
                                        Name={category.Value}
                                        Uid={category.Key}
                                        ProductUid={this.state.ProductUid}
                                        RemoveFrom={this.removeFromCategory} />)
                            }
                        </tbody>
                    </table>
                    {
                        // component for this?
                        this.state.AvailableCategories.length == 0
                            ? null
                            : (
                                <div className="row col-md-9">
                                    <div className="mb-3 col-md-4">
                                        <DropDownList
                                            Name="AvailableCategories"
                                            ClassName="custom-select d-block"
                                            Items={this.state.AvailableCategories}
                                            SelectedItem={this.state.SelectedCategoryUid}
                                            OnChange={this.setSelectedCategory} />
                                    </div>
                                </div>
                            )
                    }
                    {
                        // component for this?
                        this.state.AvailableCategories.length === 0
                            ? null
                            :
                            (
                                <div className="col-md-4 mb-3">
                                    <button onClick={() => this.addToSelectedCategory()} className="btn btn-success">Add</button>
                                </div>
                            )
                    }


                </div>
            </React.Fragment>
        )
    }
}

const mapStateToProps = (state: IShopyState): IChangeCategoriesProps => {
    console.log('mapStateToProps', state)

    return {
        AvailableCategories: state.AvailableProductCategories.map(model => ({
            Key: model.Uid,
            Value: model.Name
        })),
        ProductCategories: state.ProductCategories.map(model => ({
            Key: model.Uid,
            Value: model.Name
        }))
    }

}

const mapDispatachToProps = (dispatch: any, routeProps: RouteComponentProps): IChangeCategoriesDispatch => ({
    RemoveFrom: (productUid: string, categoryUid: string) => dispatch(RequestFactory.RemoveProductFromCategory(productUid, categoryUid)),
    AddTo: (productUid: string, categoryUid: string) => dispatch(RequestFactory.AddProductToCategory(productUid, categoryUid)),
    CategoriesLookup: () => dispatch(RequestFactory.LookupCategories()),
    GetProductCategories: () => dispatch(RequestFactory.GetProductCategories(RouteUtils.GetIdParam(routeProps)))
})

export default connect(mapStateToProps, mapDispatachToProps)(ChangeCategories);
