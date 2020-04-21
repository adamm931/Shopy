export class Routes {

    public static Root = "/"
    public static Home = "/products"

    public static Products = class {
        public static Root = "/products"
        public static Add = "/products/add"
        public static Edit = (uuid: string) => `/products/${uuid}`
        public static AddToCategory = (uuid: string, categoryUuid: string) => `/products/${uuid}/add-to-category/${categoryUuid}`
        public static RemoveFromCategory = (uuid: string, categoryUuid: string) => `/products/${uuid}/remove-from-category/${categoryUuid}`
    }

    public static Categories = class {
        public static Root = "/categories"
    }
}