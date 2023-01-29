export interface Product {
  id: string;
  ProductName: string;
  CategoryID: string;
  PurchaseingPrice: string;
  WholesaleSellingPrice:string;
  SectoralSellingPrice:string;
  HalfSectoralSellingPrice : string;
  Description:string;
  Notes:string;
  Image:string;
  IsActive:string;
  productUnits:[];
}
