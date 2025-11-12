namespace Shopping.Web.Services
{
    public interface ICatalogService
    {
        //[Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
        [Get("/catalog-service/products")]
        Task<GetProductsResponse> GetProducts(GetProductsRequest request);

        [Get("/catalog-service/products/{id}")]
        Task<GetProductByIdResponse> GetProduct(Guid id);

        [Get("/catalog-service/products/category/{category}")]
        Task<GetProductByCategoryResponse> GetProductsByCategory(string category);
    }
}
