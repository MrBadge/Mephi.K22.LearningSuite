// Type: Mephi.K22.LearningSuite.Core.ActionCollection
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class ActionCollection : CollectionBase, IBindingList, IList, ICollection, IEnumerable
  {
    [XmlIgnore]
    [NonSerialized]
    private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
    [XmlIgnore]
    [NonSerialized]
    private ListChangedEventHandler onListChanged;

    public Action this[int index]
    {
      get
      {
        return (Action) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    bool IBindingList.AllowEdit
    {
      get
      {
        return true;
      }
    }

    bool IBindingList.AllowNew
    {
      get
      {
        return true;
      }
    }

    bool IBindingList.AllowRemove
    {
      get
      {
        return true;
      }
    }

    bool IBindingList.SupportsChangeNotification
    {
      get
      {
        return true;
      }
    }

    bool IBindingList.SupportsSearching
    {
      get
      {
        return false;
      }
    }

    bool IBindingList.SupportsSorting
    {
      get
      {
        return false;
      }
    }

    bool IBindingList.IsSorted
    {
      get
      {
        throw new NotSupportedException();
      }
    }

    ListSortDirection IBindingList.SortDirection
    {
      get
      {
        throw new NotSupportedException();
      }
    }

    PropertyDescriptor IBindingList.SortProperty
    {
      get
      {
        throw new NotSupportedException();
      }
    }

    public event ListChangedEventHandler ListChanged
    {
      add
      {
        this.onListChanged += value;
      }
      remove
      {
        this.onListChanged -= value;
      }
    }

    public int Add(Action value)
    {
      return this.List.Add((object) value);
    }

    public Action AddNew()
    {
      return (Action) this.AddNew();
    }

    public void Remove(Action value)
    {
      this.List.Remove((object) value);
    }

    protected virtual void OnListChanged(ListChangedEventArgs ev)
    {
      if (this.onListChanged == null)
        return;
      this.onListChanged((object) this, ev);
    }

    protected override void OnClear()
    {
      foreach (Action action in (IEnumerable) this.List)
        action.Parent = (ActionCollection) null;
    }

    protected override void OnClearComplete()
    {
      this.OnListChanged(this.resetEvent);
    }

    protected override void OnInsertComplete(int index, object value)
    {
      ((Action) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    protected override void OnRemoveComplete(int index, object value)
    {
      ((Action) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
    }

    protected override void OnSetComplete(int index, object oldValue, object newValue)
    {
      if (oldValue == newValue)
        return;
      Action action1 = (Action) oldValue;
      Action action2 = (Action) newValue;
      action1.Parent = (ActionCollection) null;
      action2.Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    internal void ActionChanged(Action cust)
    {
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.List.IndexOf((object) cust)));
    }

    object IBindingList.AddNew()
    {
      Action action = new Action();
      this.List.Add((object) action);
      return (object) action;
    }

    void IBindingList.AddIndex(PropertyDescriptor property)
    {
      throw new NotSupportedException();
    }

    void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
    {
      throw new NotSupportedException();
    }

    int IBindingList.Find(PropertyDescriptor property, object key)
    {
      throw new NotSupportedException();
    }

    void IBindingList.RemoveIndex(PropertyDescriptor property)
    {
      throw new NotSupportedException();
    }

    void IBindingList.RemoveSort()
    {
      throw new NotSupportedException();
    }

    public Action GetLastAction()
    {
      int count = this.List.Count;
      if (count > 0)
        return (Action) this.List[count - 1];
      else
        return (Action) null;
    }
  }
}
