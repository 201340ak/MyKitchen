namespace MyKitchen.Accessors
{
    public interface IInventoryAccessor
    {
        DataContracts.Inventory Add(DataContracts.Inventory inventory);

        DataContracts.Inventory GetAll();
        
        DataContracts.Inventory Get(int id);

        DataContracts.Inventory Delete(int id);
    }
}