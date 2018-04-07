using System;
using System.Collections.Generic;
using System.Linq;
using Manatee.Trello.Internal;
using Manatee.Trello.Internal.Caching;
using Manatee.Trello.Internal.DataAccess;
using Manatee.Trello.Json;

namespace Manatee.Trello
{
	/// <summary>
	/// A read-only collection of organizations.
	/// </summary>
	public class ReadOnlyOrganizationCollection : ReadOnlyCollection<IOrganization>, IReadOnlyOrganizationCollection
	{
		private Dictionary<string, object> _additionalParameters;

		internal ReadOnlyOrganizationCollection(Func<string> getOwnerId, TrelloAuthorization auth)
			: base(getOwnerId, auth) {}
		internal ReadOnlyOrganizationCollection(ReadOnlyOrganizationCollection source, TrelloAuthorization auth)
			: this(() => source.OwnerId, auth)
		{
			if (source._additionalParameters != null)
				_additionalParameters = new Dictionary<string, object>(source._additionalParameters);
		}

		/// <summary>
		/// Retrieves a organization which matches the supplied key.
		/// </summary>
		/// <param name="key">The key to match.</param>
		/// <returns>The matching organization, or null if none found.</returns>
		/// <remarks>
		/// Matches on Organization.Id, Organization.Name, and Organization.DisplayName.  Comparison is case-sensitive.
		/// </remarks>
		public IOrganization this[string key] => GetByKey(key);

		/// <summary>
		/// Adds a filter to the collection.
		/// </summary>
		/// <param name="filter">The filter value.</param>
		public void Filter(OrganizationFilter filter)
		{
			if (_additionalParameters == null)
				_additionalParameters = new Dictionary<string, object>();
			_additionalParameters["filter"] = filter.GetDescription();
		}

		/// <summary>
		/// Implement to provide data to the collection.
		/// </summary>
		protected sealed override void Update()
		{
			IncorporateLimit(_additionalParameters);

			var endpoint = EndpointFactory.Build(EntityRequestType.Member_Read_Organizations, new Dictionary<string, object> { { "_id", OwnerId } });
			var newData = JsonRepository.Execute<List<IJsonOrganization>>(Auth, endpoint, _additionalParameters);

			Items.Clear();
			Items.AddRange(newData.Select(jo =>
				{
					var org = CachingObjectFactory.GetFromCache<Organization>(jo, Auth);
					org.Json = jo;
					return org;
				}));
		}

		private IOrganization GetByKey(string key)
		{
			return this.FirstOrDefault(o => key.In(o.Id, o.Name, o.DisplayName));
		}
	}
}