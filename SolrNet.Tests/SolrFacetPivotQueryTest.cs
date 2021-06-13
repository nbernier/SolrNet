using Xunit;
using SolrNet.Impl.FacetQuerySerializers;
using SolrNet.Utils;

namespace SolrNet.Tests {
    
    public class SolrFacetPivotQueryTest {
        private static readonly SolrFacetPivotQuerySerializer serializer = new SolrFacetPivotQuerySerializer();

        [Fact]
        public void SinglePivotTest() {
            var q = new SolrFacetPivotQuery {
                Fields = new[] {new PivotFields("manu_str", "inStock")},
                MinCount = 1
            };

            var r = serializer.Serialize(q);
            Assert.Contains(KV.Create("facet.pivot", "manu_str,inStock"),r);
            Assert.Contains(KV.Create("facet.pivot.mincount", "1"), r);
        }

        [Fact]
        public void SinglePivotTestWithoutMinCount() {
            var q = new SolrFacetPivotQuery {
                Fields = new[] { new PivotFields("manu_str","inStock")}
            };

            var r = serializer.Serialize(q);
            Assert.Contains( KV.Create("facet.pivot", "manu_str,inStock"), r);
            foreach (var kvPair in r) {
                Assert.DoesNotContain("facet.pivot.mincount", kvPair.Key);
            }
        }

        [Fact]
        public void MultiplePivotTest() {
            var q = new SolrFacetPivotQuery {
                Fields = new[] { new PivotFields("manu_str","inStock"), new PivotFields("inStock", "cat"), },
                MinCount = 1
            };

            var r = serializer.Serialize(q);
            Assert.Contains( KV.Create("facet.pivot", "manu_str,inStock"), r);
            Assert.Contains( KV.Create("facet.pivot", "inStock,cat"), r);
            Assert.Contains( KV.Create("facet.pivot.mincount", "1"), r);
        }
    }
}
