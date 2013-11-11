// Type: Mephi.K22.LearningSuite.Transport.FF.FFTest
// Assembly: Mephi.K22.LearningSuite.Transport.FF, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DA688CD5-CC79-4F9D-90F5-6DF17C731483
// Assembly location: C:\Dropbox\MEPhI\Optimization_methods\Одном\Mephi.K22.LearningSuite.Transport.FF.dll

using Mephi.K22.LearningSuite.Core;
using Mephi.K22.LearningSuite.Transport.FF.Base;
using System.Collections;

namespace Mephi.K22.LearningSuite.Transport.FF
{
  public class FFTest
  {
    internal bool isOver = false;
    internal State methodState = State.create;
    internal int tempNodeInd = 0;
    internal int flowChange = 0;
    private Net _net;

    public object[] InnerState
    {
      get
      {
        return new object[3]
        {
          (object) this.methodState,
          (object) this.tempNodeInd,
          (object) this.isOver
        };
      }
      set
      {
        object[] objArray = value;
        this.methodState = (State) objArray[0];
        this.tempNodeInd = (int) objArray[1];
        this.isOver = (bool) objArray[2];
      }
    }

    public FFTest(Net n)
    {
      this._net = n;
    }

    public FFTest TestCopy()
    {
      return new FFTest(this._net)
      {
        methodState = this.methodState
      };
    }

    public bool IsOver()
    {
      return this.isOver;
    }

    public ActionResult TestAction(Action act)
    {
      ActionResult actionResult1 = new ActionResult();
      ArrayList arrayList1 = new ArrayList();
      switch (act.ActionType)
      {
        case (byte) 1:
          string str1 = string.Empty;
          ArrayList arrayList2 = new ArrayList();
          if (this.methodState == State.begin || this.methodState == State.create)
          {
            if (this._net.GetArc((int) act.Parameters[0], (int) act.Parameters[1]).H >= (int) act.Parameters[2])
            {
              actionResult1.Accuracy = AccuracyType.yes;
              break;
            }
            else
            {
              actionResult1.Accuracy = AccuracyType.no;
              actionResult1.Comment = "Поток не может быть больше максимальной пропускной способности";
              arrayList2.Add((object) 1);
              break;
            }
          }
          else if (this.methodState == State.change)
          {
            actionResult1.Accuracy = AccuracyType.yes;
            int num1 = (int) act.Parameters[0];
            int num2 = (int) act.Parameters[1];
            int num3 = (int) act.Parameters[2];
            int num4 = (int) act.Parameters[3];
            Node node = this._net[this.tempNodeInd];
            if (node != null)
            {
              if (node.IsMark)
              {
                if (num2 == node.Number && num1 == node.Z && node.Plus || num2 == node.Z && num1 == node.Number && !node.Plus)
                {
                  if ((num3 - num4 != this.flowChange || !node.Plus) && (num4 - num3 != this.flowChange || node.Plus))
                  {
                    actionResult1.Accuracy = AccuracyType.no;
                    actionResult1.Comment = "неверное изменение потока";
                    arrayList2.Add((object) 8);
                  }
                }
                else
                {
                  actionResult1.Accuracy = AccuracyType.no;
                  actionResult1.Comment = "неверная дуга";
                  arrayList2.Add((object) 9);
                }
                this.tempNodeInd = !node.Plus ? num2 : num1;
              }
              else
              {
                actionResult1.Accuracy = AccuracyType.no;
                actionResult1.Comment = "неверная дуга";
                arrayList2.Add((object) 9);
              }
            }
            else
            {
              actionResult1.Accuracy = AccuracyType.no;
              actionResult1.Comment = "неверная дуга";
              arrayList2.Add((object) 9);
            }
            if (num1 == this._net.StartNode.Number)
            {
              this.methodState = State.unmark;
              break;
            }
            else
              break;
          }
          else
          {
            actionResult1.Accuracy = AccuracyType.no;
            actionResult1.Comment = "нельзя менять поток";
            this.methodState = State.change;
            arrayList2.Add((object) 11);
            break;
          }
        case (byte) 2:
          bool flag1 = true;
          actionResult1.Accuracy = AccuracyType.yes;
          if (this.methodState == State.begin || this.methodState == State.create)
          {
            int num1 = 0;
            foreach (Arc arc in (CollectionBase) ((ArcNode) this._net.NodeArc[(object) this._net.StartNode]).StartArcs)
              num1 += arc.F;
            foreach (Arc arc in (CollectionBase) ((ArcNode) this._net.NodeArc[(object) this._net.EndNode]).EndArcs)
              num1 -= arc.F;
            if (num1 != 0)
              flag1 = false;
            foreach (Node node in (CollectionBase) this._net.Nodes)
            {
              ArcNode arcNode = (ArcNode) this._net.NodeArc[(object) node];
              if (node != this._net.StartNode && node != this._net.EndNode)
              {
                int num2 = 0;
                foreach (Arc arc in (CollectionBase) arcNode.StartArcs)
                  num2 += arc.F;
                foreach (Arc arc in (CollectionBase) arcNode.EndArcs)
                  num2 -= arc.F;
                if (num2 != 0)
                  flag1 = false;
              }
            }
            this.methodState = State.mark;
          }
          if (this.methodState == State.unmark)
          {
            int num = 0;
            foreach (Node node in (CollectionBase) this._net.Nodes)
            {
              if (node.IsMark && this._net.StartNode != node)
                ++num;
            }
            if (num == 0)
              this.methodState = State.mark;
          }
          if (this.methodState == State.mark)
          {
            if (!flag1)
            {
              arrayList1.Add((object) 2);
              actionResult1.Accuracy = AccuracyType.no;
              actionResult1.Comment = "Нет баланса потока в сети";
            }
            if (actionResult1.Comment != string.Empty)
            {
              ActionResult actionResult2 = actionResult1;
              string str2 = actionResult2.Comment + "; ";
              actionResult2.Comment = str2;
            }
            int num1 = (int) act.Parameters[0];
            bool flag2 = (bool) act.Parameters[1];
            int index = (int) act.Parameters[2];
            bool flag3 = (bool) act.Parameters[3];
            bool flag4 = (bool) act.Parameters[4];
            int num2 = (int) act.Parameters[5];
            if (this._net.StartNode.IsMark)
            {
              if (flag3)
              {
                Node node = this._net[index];
                if (node != null)
                {
                  Arc arc = this._net.GetArc(node.Number, num1);
                  if (arc != null)
                  {
                    int num3 = !node.Inf ? (arc.H - arc.F >= node.E ? node.E : arc.H - arc.F) : arc.H - arc.F;
                    if (num2 != num3 || num2 <= 0)
                    {
                      arrayList1.Add((object) "5");
                      actionResult1.Accuracy = AccuracyType.no;
                      ActionResult actionResult2 = actionResult1;
                      string str2 = actionResult2.Comment + string.Format("не верно определен E (д.б. {0})", (object) num3);
                      actionResult2.Comment = str2;
                    }
                  }
                  else
                  {
                    arrayList1.Add((object) "4");
                    actionResult1.Accuracy = AccuracyType.no;
                    ActionResult actionResult2 = actionResult1;
                    string str2 = actionResult2.Comment + "пометка вершины определена неверно (Z,+/-)";
                    actionResult2.Comment = str2;
                  }
                }
                else
                {
                  arrayList1.Add((object) "4");
                  actionResult1.Accuracy = AccuracyType.no;
                  ActionResult actionResult2 = actionResult1;
                  string str2 = actionResult2.Comment + "пометка вершины определена неверно (Z,+/-)";
                  actionResult2.Comment = str2;
                }
              }
              else
              {
                Node node = this._net[index];
                bool flag5 = false;
                if (node != null)
                {
                  if (node.IsMark && !node.IsEmpty)
                  {
                    Arc arc = this._net.GetArc(num1, node.Number);
                    if (arc != null)
                    {
                      if (arc.F > 0)
                      {
                        foreach (Arc a in (CollectionBase) ((ArcNode) this._net.NodeArc[(object) node]).StartArcs)
                        {
                          if (!this._net.GetArcTo(a).IsMark && a.H > a.F)
                          {
                            flag5 = true;
                            break;
                          }
                        }
                        if (flag5)
                        {
                          arrayList1.Add((object) "6");
                          actionResult1.Accuracy = AccuracyType.no;
                          ActionResult actionResult2 = actionResult1;
                          string str2 = actionResult2.Comment + "Нельзя помечать с -, есть вершины для пометки с +";
                          actionResult2.Comment = str2;
                        }
                        else
                        {
                          int num3 = arc.F >= node.E ? node.E : arc.F;
                          if (num2 != num3 || num2 <= 0)
                          {
                            arrayList1.Add((object) "5");
                            actionResult1.Accuracy = AccuracyType.no;
                            ActionResult actionResult2 = actionResult1;
                            string str2 = actionResult2.Comment + string.Format("не верно определен E (д.б. {0})", (object) num3);
                            actionResult2.Comment = str2;
                          }
                        }
                      }
                      else
                      {
                        arrayList1.Add((object) "7");
                        actionResult1.Accuracy = AccuracyType.no;
                        ActionResult actionResult2 = actionResult1;
                        string str2 = actionResult2.Comment + "у дуги F д.б. > 0";
                        actionResult2.Comment = str2;
                      }
                    }
                    else
                    {
                      arrayList1.Add((object) "4");
                      actionResult1.Accuracy = AccuracyType.no;
                      ActionResult actionResult2 = actionResult1;
                      string str2 = actionResult2.Comment + "пометка вершины определена неверно (Z,+/-)";
                      actionResult2.Comment = str2;
                    }
                  }
                  else
                  {
                    arrayList1.Add((object) "4");
                    actionResult1.Accuracy = AccuracyType.no;
                    ActionResult actionResult2 = actionResult1;
                    string str2 = actionResult2.Comment + "пометка вершины определена неверно (Z,+/-)";
                    actionResult2.Comment = str2;
                  }
                }
                else
                {
                  arrayList1.Add((object) "4");
                  actionResult1.Accuracy = AccuracyType.no;
                  ActionResult actionResult2 = actionResult1;
                  string str2 = actionResult2.Comment + "пометка вершины определена неверно (Z,+/-)";
                  actionResult2.Comment = str2;
                }
              }
            }
            else if (this._net.StartNode.Number == num1)
            {
              if (!flag2 || flag3 || !flag4)
              {
                arrayList1.Add((object) 3);
                actionResult1.Accuracy = AccuracyType.no;
                actionResult1.Comment = "Не верно помечен исток (д.б. (-;inf))";
              }
            }
            else
            {
              arrayList1.Add((object) 4);
              actionResult1.Accuracy = AccuracyType.no;
              actionResult1.Comment = "Первым помечается исток";
            }
            if (this._net.EndNode.Number == num1)
            {
              this.tempNodeInd = num1;
              this.flowChange = num2;
              this.methodState = State.change;
              break;
            }
            else
              break;
          }
          else
          {
            arrayList1.Add((object) 10);
            actionResult1.Accuracy = AccuracyType.no;
            actionResult1.Comment = "Нельзя ставить пометки";
            this.methodState = State.mark;
            break;
          }
        case (byte) 3:
          actionResult1.Accuracy = AccuracyType.yes;
          if (this.methodState == State.unmark)
          {
            int num = 0;
            foreach (Node node in (CollectionBase) this._net.Nodes)
            {
              if (node.IsMark)
                ++num;
            }
            if (num == 0)
            {
              this.methodState = State.mark;
              break;
            }
            else
              break;
          }
          else
          {
            arrayList1.Add((object) 12);
            actionResult1.Accuracy = AccuracyType.no;
            actionResult1.Comment = "Нельзя удалять пометки";
            this.methodState = State.unmark;
            break;
          }
        case (byte) 4:
          actionResult1.Accuracy = AccuracyType.yes;
          int num5 = 0;
          foreach (Node node in (CollectionBase) this._net.Nodes)
          {
            if (node.IsMark)
            {
              ArcNode arcNode = (ArcNode) this._net.NodeArc[(object) node];
              foreach (Arc a in (CollectionBase) arcNode.StartArcs)
              {
                if (a.F < a.H && !this._net.GetArcTo(a).IsMark)
                {
                  ++num5;
                  break;
                }
              }
              foreach (Arc a in (CollectionBase) arcNode.EndArcs)
              {
                if (a.F > 0 && !this._net.GetArcFrom(a).IsMark)
                {
                  ++num5;
                  break;
                }
              }
            }
            else if (node == this._net.StartNode && !node.IsMark)
            {
              ++num5;
              break;
            }
          }
          if (num5 > 0)
          {
            actionResult1.Accuracy = AccuracyType.no;
            actionResult1.Comment = "Есть вершины для расставления пометок";
            arrayList1.Add((object) 13);
          }
          else
          {
            ArcNode arcNode = (ArcNode) this._net.NodeArc[(object) this._net.StartNode];
            int num1 = 0;
            foreach (Arc arc in (CollectionBase) arcNode.StartArcs)
              num1 += arc.F;
            if (num1 != (int) act.Parameters[0])
            {
              actionResult1.Accuracy = AccuracyType.no;
              actionResult1.Comment = "Не верно определен поток в сети";
              arrayList1.Add((object) 14);
            }
          }
          this.isOver = true;
          break;
        case (byte) 5:
          actionResult1.Accuracy = AccuracyType.notSpecified;
          if (this.methodState == State.create)
          {
            this.methodState = State.begin;
            break;
          }
          else
          {
            arrayList1.Add((object) 14);
            actionResult1.Accuracy = AccuracyType.no;
            actionResult1.Comment = "Нельзя создавать сеть";
            this.methodState = State.begin;
            break;
          }
      }
      return actionResult1;
    }
  }
}
