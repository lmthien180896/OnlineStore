using System;

namespace OnlineStore.UseCase.Categories
{
    [Serializable]
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(int id) : base($"Cannot find category with ID {id}.")
        {
        }
    }
}