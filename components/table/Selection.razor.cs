﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    public partial class Selection : ColumnBase, ISelectionColumn
    {
        [Parameter] public string Type { get; set; } = "checkbox";

        [Parameter] public bool Disabled { get; set; }

        [Parameter] public string Key { get; set; }

        [CascadingParameter(Name = "RowIndex")]
        public int RowIndex { get; set; }

        bool ISelectionColumn.Checked
        {
            get => _checked;
            set => _checked = value;
        }

        private bool _checked;

        private bool Indeterminate => IsHeader
                                      && this.RowSelections.Any(x => x.Checked)
                                      && !this.RowSelections.All(x => x.Checked);

        public IList<ISelectionColumn> RowSelections { get; set; } = new List<ISelectionColumn>();

        private int[] _selectedIndexes;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (Table == null)
            {
                return;
            }

            if (IsHeader)
            {
                Table.Selection = this;
            }
            else
            {
                Table?.Selection?.RowSelections.Add(this);
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (IsHeader && Type == "radio" && RowSelections.Count(x => x.Checked) > 1)
            {
                var first = RowSelections.FirstOrDefault(x => x.Checked);
                if (first != null)
                {
                    Table?.Selection.RowSelections.Where(x => x.Index != first.Index).ForEach(x => x.Check(false));
                }
            }
        }

        private void HandleCheckedChange(bool @checked)
        {
            Check(@checked);

            if (this.IsHeader)
            {
                RowSelections.Where(x => !x.Disabled).ForEach(x => x.Check(@checked));
                InvokeSelectedRowsChange();
            }
            else
            {
                if (Type == "radio")
                {
                    Table?.Selection.RowSelections.Where(x => x.RowIndex != this.RowIndex).ForEach(x => x.Check(false));
                }

                Table?.Selection.InvokeSelectedRowsChange();
            }
        }

        bool ISelectionColumn.Check(bool @checked)
        {
            return this.Check(@checked);
        }

        private bool Check(bool @checked)
        {
            if (this._checked != @checked)
            {
                this._checked = @checked;
                StateHasChanged();

                return true;
            }

            return false;
        }

        public void InvokeSelectedRowsChange()
        {
            if (IsHeader)
            {
                Table.SelectionChanged();

                StateHasChanged();
            }
        }

        public void ChangeSelection(int[] indexes)
        {
            if (indexes == null || !indexes.Any())
            {
                this.Table.Selection.RowSelections.ForEach(x => x.Check(false));
                this.Table.Selection.Check(false);
            }
            else
            {
                this.Table.Selection.RowSelections.ForEach(x => x.Check(x.RowIndex.IsIn(indexes)));
                this.Table.Selection.StateHasChanged();
            }
        }

        public void SetSelection(string[] keys)
        {
            if (keys == null || !keys.Any())
            {
                this.Table.Selection.RowSelections.ForEach(x => x.Check(false));
                this.Table.Selection.Check(false);
            }
            else
            {
                this.Table.Selection.RowSelections.ForEach(x => x.Check(x.Key.IsIn(keys)));
                this.Table.Selection.StateHasChanged();
            }
        }

        public void ChangeOnPaging()
        {
            this.ChangeSelection(Table.GetSelectedIndex());
        }

        void ISelectionColumn.StateHasChanged()
        {
            if (IsHeader)
            {
                _checked = this.RowSelections.All(x => x.Checked);
                StateHasChanged();
            }
        }
    }
}
