﻿namespace AntDesign
{
    public interface ITable
    {
        internal ISelectionColumn Selection { get; set; }

        internal void SelectionChanged();

        internal void Refresh();

        internal void ReloadAndInvokeChange();

        void SetSelection(string[] keys);

        internal int[] GetSelectedCacheKeys();

        void ReloadData();
    }
}
