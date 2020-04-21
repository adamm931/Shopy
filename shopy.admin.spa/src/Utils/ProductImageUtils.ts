import { ProductImageName } from "../Enums/ProductImageNames"

export class ProdutImageUtils {

    public static GetImageNameByIndex = (index: number) => {
        let imageMapping = ProductImageNameByIndex();
        let imageName = imageMapping[index] || ProductImageName.Empty

        return imageName
    }
}

const ProductImageNameByIndex = (): { [key: number]: string } => {

    let mapping: { [key: number]: string } = {}
    mapping[0] = ProductImageName.Main
    mapping[1] = ProductImageName.Second
    mapping[2] = ProductImageName.Third

    return mapping
}

