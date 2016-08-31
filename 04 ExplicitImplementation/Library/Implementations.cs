namespace Library
{
    public class StandardCatalog : ISaveable, IPersistable
    {
        public void Load()
        {
        }

        public string Save()
        {
            return "Catalog Save";
        }
    }

    public class ExplicitCatalog : ISaveable, IPersistable
    {
        //public string Save()
        //{
        //    return "Catalog Save";
        //}

        // Access modifiers are not allowed in explicit interface implementations.
        // This is the same reason why we cannot add access modifiers within the interface 
        // itself, as the purpose of using an interface is for it to be publically consumed.
        string ISaveable.Save()
        {
            return "ISaveable Save";
        }

        string IPersistable.Save()
        {
            return "IPersistable Save";
        }
    }

    public class Catalog : ISaveable, IVoidSaveable
    {
        // C# does not allow method overloading based solely on different return types.
        // ISaveable's Save method returns string while IVoidSaveable's Save method is void.
        // To differentiate between them, we must explicitly implement the methods.   
        string ISaveable.Save()
        {
            throw new System.NotImplementedException();
        }

        void IVoidSaveable.Save()
        {
            throw new System.NotImplementedException();
        }
    }

}
