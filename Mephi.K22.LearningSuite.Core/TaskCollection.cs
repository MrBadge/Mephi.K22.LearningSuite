// Type: Mephi.K22.LearningSuite.Core.TaskCollection
// Assembly: Mephi.K22.LearningSuite.Core, Version=0.1.3236.13212, Culture=neutral, PublicKeyToken=null
// MVID: 907AAF44-1B7B-4469-B00E-B807E27EEDA6
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Core.dll

using DevExpress.Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Mephi.K22.LearningSuite.Core
{
  [Serializable]
  public class TaskCollection : CollectionBase, IBindingList, IList, ICollection, IEnumerable, IRelationList
  {
    [XmlIgnore]
    private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
    [XmlIgnore]
    private ListChangedEventHandler onListChanged;

    public Task this[int index]
    {
      get
      {
        return (Task) this.List[index];
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

    int IRelationList.RelationCount
    {
      get
      {
        return 1;
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

    public int Add(Task value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(Task value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, Task value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(Task value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(Task value)
    {
      return this.List.Contains((object) value);
    }

    protected virtual void OnListChanged(ListChangedEventArgs ev)
    {
      if (this.onListChanged == null)
        return;
      this.onListChanged((object) this, ev);
    }

    protected override void OnClear()
    {
      foreach (Task task in (IEnumerable) this.List)
        task.Parent = (TaskCollection) null;
    }

    protected override void OnClearComplete()
    {
      this.OnListChanged(this.resetEvent);
    }

    protected override void OnInsertComplete(int index, object value)
    {
      ((Task) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    protected override void OnRemoveComplete(int index, object value)
    {
      ((Task) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
    }

    protected override void OnSetComplete(int index, object oldValue, object newValue)
    {
      if (oldValue == newValue)
        return;
      Task task1 = (Task) oldValue;
      Task task2 = (Task) newValue;
      task1.Parent = (TaskCollection) null;
      task2.Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    public void ElementChanged(Task el)
    {
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.List.IndexOf((object) el)));
    }

    object IBindingList.AddNew()
    {
      Task task = new Task();
      this.List.Add((object) task);
      return (object) task;
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

    string IRelationList.GetRelationName(int index, int relationIndex)
    {
      return "Retries";
    }

    IList IRelationList.GetDetailList(int index, int relationIndex)
    {
      return (IList) this[index].Retries;
    }

    bool IRelationList.IsMasterRowEmpty(int index, int relationIndex)
    {
      return false;
    }
  }
}
