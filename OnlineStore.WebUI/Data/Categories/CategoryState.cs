using System;

namespace OnlineStore.WebUI.Data.Categories
{
    public class CategoryState
    {
        public CategoryViewModel Category { get; private set; }

        public event Action OnChange;

        public void SetAppState(CategoryViewModel category)
        {
            Category = category;
            OnChange?.Invoke();
        }
    }
}