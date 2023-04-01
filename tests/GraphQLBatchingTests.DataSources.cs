using UnitTestsPackage.Dtos;

namespace UnitTestsPackage
{
    public sealed partial class GraphQLBatchingTests
    {
        private static class DataSouces
        {
            public static IEnumerable<object[]> GetOneItemOrNullEmptyData { get; } = new[]
            {
                new object[]
                {
                    "",
                    "items",
                    new List<ItemsDataDto>
                    {
                    },
                },
                new object[]
                {
                    "data: {\"not_items\": [] } event: complete\n\n\n ",
                    "items",
                    new List<ItemsDataDto>
                    {
                        new ItemsDataDto
                        {
                            id_Items = string.Empty,
                        },
                    },
                },
                new object[]
                {
                    "event: next\ndata: {\"data\":{\"itemsData\":[{\"id_Items\":\"01\"}]}}\n\nevent: complete\n\n",
                    "itemsData",
                    new List<ItemsDataDto>
                    {
                        new ItemsDataDto
                        {
                            id_Items = "01",
                        },
                    },
                }
            };
        }
    }
}
