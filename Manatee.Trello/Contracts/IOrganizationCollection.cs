namespace Manatee.Trello
{
	/// <summary>
	/// A collection of organizations.
	/// </summary>
	public interface IOrganizationCollection : IReadOnlyOrganizationCollection
	{
		/// <summary>
		/// Creates a new organization.
		/// </summary>
		/// <param name="displayName">The display name of the organization to add.</param>
		/// <returns>The <see cref="IOrganization"/> generated by Trello.</returns>
		/// <remarks>The organization's name will be derived from the display name and can be changed later.</remarks>
		IOrganization Add(string displayName);
	}
}