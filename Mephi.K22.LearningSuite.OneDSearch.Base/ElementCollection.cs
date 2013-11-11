// Type: Mephi.K22.LearningSuite.OneDSearch.Base.ElementCollection
// Assembly: Mephi.K22.LearningSuite.OneDSearch.Base, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EF8375E-BF87-46B7-A32A-E286B4EDBF9E
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.OneDSearch.Base.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Mephi.K22.LearningSuite.OneDSearch.Base
{
  public class ElementCollection : CollectionBase, IBindingList, IList, ICollection, IEnumerable
  {
    private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
    private ListChangedEventHandler onListChanged;

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

    public virtual int Add(Element value)
    {
      return this.List.Add((object) value);
    }

    public virtual int IndexOf(Element value)
    {
      return this.List.IndexOf((object) value);
    }

    public virtual void Insert(int index, Element value)
    {
      this.List.Insert(index, (object) value);
    }

    public virtual void Remove(Element value)
    {
      this.List.Remove((object) value);
    }

    public virtual bool Contains(Element value)
    {
      return this.List.Contains((object) value);
    }

    public virtual void Draw(Graphics g, float scale, float zeroX, float zeroY)
    {
      for (int index = this.List.Count - 1; index >= 0; --index)
      {
        if (((Element) this.List[index]).DrawObject != null)
          ((Element) this.List[index]).DrawObject.Draw(g, scale, zeroX, zeroY);
      }
    }

    public void MakeDrawObjects(float scale, float zeroPointX, float zeroPointY)
    {
    }

    public void UnSelectAll()
    {
      if (this.List == null)
        return;
      foreach (Element element in (IEnumerable) this.List)
      {
        if (element.DrawObject != null)
          element.DrawObject.IsSelected = false;
      }
    }

    public Element GetClicked(int x, int y)
    {
      foreach (Element element in (IEnumerable) this.List)
      {
        if (element.HitTest(x, y))
          return element;
      }
      return (Element) null;
    }

    protected virtual void OnListChanged(ListChangedEventArgs ev)
    {
      if (this.onListChanged == null)
        return;
      this.onListChanged((object) this, ev);
    }

    protected override void OnClear()
    {
      foreach (Element element in (IEnumerable) this.List)
        element.Parent = (ElementCollection) null;
    }

    protected override void OnClearComplete()
    {
      this.OnListChanged(this.resetEvent);
    }

    protected override void OnInsertComplete(int index, object value)
    {
      ((Element) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    protected override void OnRemoveComplete(int index, object value)
    {
      ((Element) value).Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
    }

    protected override void OnSetComplete(int index, object oldValue, object newValue)
    {
      if (oldValue == newValue)
        return;
      Element element1 = (Element) oldValue;
      Element element2 = (Element) newValue;
      element1.Parent = (ElementCollection) null;
      element2.Parent = this;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    public void ElementChanged(Element el)
    {
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.List.IndexOf((object) el)));
    }

    object IBindingList.AddNew()
    {
      object obj = new object();
      this.List.Add(obj);
      return obj;
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
