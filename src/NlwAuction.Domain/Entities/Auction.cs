using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace NlwAuction.Domain.Entities;

public class Auction : BaseEntity
{
	private ICollection<Item> _items = new List<Item>();
	public string Name { get; set; } = string.Empty;
	public DateTime StartsAt { get; set; }
	public DateTime EndsAt { get; set; }
	public ICollection<Item> Items
	{
		get => new ReadOnlyCollection<Item>(_items.ToImmutableList());
		set => InitializeItems(value);
	}

	public void InitializeItems(ICollection<Item> items)
	{
		if (_items.Count == 0)
			_items = items;
	}

	public void AddItem(Item item)
	{
		_items.Add(item);
	}

	public void RemoveItem(Item item)
	{
		_items.Remove(item);
	}
}
