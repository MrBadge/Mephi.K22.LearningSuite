// Type: Mephi.K22.LearningSuite.Core.RetryCollection
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using System;
using System.Collections;
using System.ComponentModel;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class RetryCollection : CollectionBase, IBindingList, IList, ICollection, IEnumerable
  {
    private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
    private ListChangedEventHandler onListChanged;

    public Retry this[int index]
    {
      get
      {
        return (Retry) this.List[index];
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

    public int Add(Retry value)
    {
      return this.List.Add((object) value);
    }

    public void Remove(Retry value)
    {
      this.List.Remove((object) value);
    }

    public int IndexOf(Retry value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, Retry value)
    {
      this.List.Insert(index, (object) value);
    }

    public bool Contains(Retry value)
    {
      return this.List.Contains((object) value);
    }

    public Retry GetRetry(int num)
    {
      foreach (Retry retry in (IEnumerable) this.List)
      {
        if (retry.RetryNum == num)
          return retry;
      }
      return (Retry) null;
    }

    protected virtual void OnListChanged(ListChangedEventArgs ev)
    {
      if (this.onListChanged == null)
        return;
      this.onListChanged((object) this, ev);
    }

    protected override void OnClear()
    {
      foreach (Retry retry in (IEnumerable) this.List)
        retry.Parent = (RetryCollection) null;
    }

    protected override void OnClearComplete()
    {
      this.OnListChanged(this.resetEvent);
    }

    protected override void OnInsertComplete(int index, object value)
    {
      ((Retry) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    protected override void OnRemoveComplete(int index, object value)
    {
      ((Retry) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
    }

    protected override void OnSetComplete(int index, object oldValue, object newValue)
    {
      if (oldValue == newValue)
        return;
      Retry retry1 = (Retry) oldValue;
      Retry retry2 = (Retry) newValue;
      retry1.Parent = (RetryCollection) null;
      retry2.Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    public void ElementChanged(Retry el)
    {
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.List.IndexOf((object) el)));
    }

    object IBindingList.AddNew()
    {
      Retry retry = new Retry();
      this.List.Add((object) retry);
      return (object) retry;
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
  }
}
