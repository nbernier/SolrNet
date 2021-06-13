﻿#region license
// Copyright (c) 2007-2010 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using SolrNet.Attributes;

namespace SolrNet.Tests.Integration.Sample {
	public class Product {
		[SolrUniqueKey("id")]
		public string Id { get; set; }

		[SolrField("name")]
		public ICollection<string> Name { get; set; }

		[SolrField("manu")]
		public ICollection<string> Manufacturer { get; set; }

		[SolrField("cat")]
		public ICollection<string> Categories { get; set; }

		[SolrField("features")]
		public ICollection<string> Features { get; set; }

		[SolrField("weight")]
		public ICollection<float> Weight { get; set; }

		[SolrField("price")]
		public ICollection<decimal> Price { get; set; }

		[SolrField("popularity")]
		public ICollection<int> Popularity { get; set; }

		[SolrField("inStock")]
		public ICollection<bool> InStock { get; set; }

        [SolrField("price_c")]
        public ICollection<Money> PriceMoney { get; set; }
	}
}
