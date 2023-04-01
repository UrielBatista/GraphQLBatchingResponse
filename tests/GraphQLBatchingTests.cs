using FluentAssertions;
using GraphQLBatchingResponse;
using UnitTestsPackage.Dtos;

namespace UnitTestsPackage
{
    [TestClass]
    public sealed partial class GraphQLBatchingTests
    {
        [DataTestMethod]
        [DynamicData(nameof(DataSouces.GetOneItemOrNullEmptyData), typeof(DataSouces))]
        public void GraphQLBatchingMapperShouldReturnArrayWithOneElementWhenDataContainsOneElementAndReturnNotFound(
            string dataReturn,
            string key,
            List<ItemsDataDto> itemsDataDtos)
        {
            // Act
            var result = GraphQLBatching
                .GraphQLBatchingMapper<ItemsDataDto>(dataReturn, key)
                .ToList();

            // Assert
            _ = result
                .Should()
                .BeOfType(typeof(List<ItemsDataDto>))
                .Equals(itemsDataDtos);
        }
    }
}
