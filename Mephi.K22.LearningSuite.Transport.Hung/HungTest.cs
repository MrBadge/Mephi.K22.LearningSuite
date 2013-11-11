namespace Mephi.K22.LearningSuite.Transport.Hung
{
    using Mephi.K22.LearningSuite.Core;
    using Mephi.K22.LearningSuite.Transport.FF.Base;
    using Mephi.K22.LearningSuite.Transport.Hung.Base;
    using System;
    using System.Collections;

    public class HungTest
    {
        private Net _net;
        private ItemNodePoint[] _prevInps;
        private Net _prevNet;
        private HungTable _prevTable;
        private HungTable _startTable;
        internal int flowChange = 0;
        internal bool isOver = false;
        internal Mephi.K22.LearningSuite.Transport.Hung.State methodState = Mephi.K22.LearningSuite.Transport.Hung.State.start;
        internal int tempNodeInd = 0;

        public HungTest(HungTable startTable, Net net)
        {
            this._startTable = startTable;
            this._prevTable = new HungTable(this._startTable.DimV, this._startTable.DimH);
            this._net = net;
        }

        private int CheckNet(HungTable currTable, ItemNodePoint[] inps, Net net, ArrayList errKeys, ref string comment)
        {
            int num = 0;
            if (net.Nodes.Count == ((currTable.DimH + currTable.DimV) + 2))
            {
                int num2 = 0;
                int num3 = 0;
                int number = 0;
                int num5 = 0;
                for (int i = 0; i < inps.Length; i++)
                {
                    ItemNodePoint point = inps[i];
                    if (point.Point.PointType == PointType.factory)
                    {
                        num2++;
                    }
                    else if (point.Point.PointType == PointType.consumer)
                    {
                        num3++;
                    }
                    else if (point.Point.PointType == PointType.source)
                    {
                        number = point.Node.Number;
                    }
                    else if (point.Point.PointType == PointType.target)
                    {
                        num5 = point.Node.Number;
                    }
                }
                if ((num2 == currTable.DimV) && (num3 == currTable.DimH))
                {
                    Node node = net[number];
                    Node node2 = net[num5];
                    if ((node != null) && (node2 != null))
                    {
                        if (((ArcNode) net.NodeArc[node]).EndArcs.Count != 0)
                        {
                            num--;
                            errKeys.Add(7);
                            comment = comment + string.Format("Неверно задана вершина-исток; ", new object[0]);
                        }
                        if (((ArcNode) net.NodeArc[node2]).StartArcs.Count != 0)
                        {
                            num--;
                            errKeys.Add(8);
                            comment = comment + string.Format("Неверно задана вершина-сток; ", new object[0]);
                        }
                        foreach (Arc arc in ((ArcNode) net.NodeArc[node]).StartArcs)
                        {
                            int index = 0;
                            index = 0;
                            while (index < inps.Length)
                            {
                                if (inps[index].Node.Number == net.GetArcTo(arc).Number)
                                {
                                    break;
                                }
                                index++;
                            }
                            if ((index >= 0) && (index < inps.Length))
                            {
                                if (inps[index].Point.PointType != PointType.factory)
                                {
                                    num--;
                                    errKeys.Add(9);
                                    comment = comment + string.Format("Дуга ({0}-{1}) из истока может идти только в п. производства; ", node.Number, inps[index].Node.Number);
                                }
                            }
                            else
                            {
                                num--;
                            }
                        }
                        foreach (Arc arc2 in ((ArcNode) net.NodeArc[node2]).EndArcs)
                        {
                            int num8 = 0;
                            num8 = 0;
                            while (num8 < inps.Length)
                            {
                                if (inps[num8].Node.Number == net.GetArcFrom(arc2).Number)
                                {
                                    break;
                                }
                                num8++;
                            }
                            if ((num8 >= 0) && (num8 < inps.Length))
                            {
                                if (inps[num8].Point.PointType != PointType.consumer)
                                {
                                    num--;
                                    errKeys.Add(10);
                                    comment = comment + string.Format("Дуга ({0}-{1}) в сток может идти только от п. потребления; ", inps[num8].Node.Number, node2.Number);
                                }
                            }
                            else
                            {
                                num--;
                            }
                        }
                        for (int j = 0; j < inps.Length; j++)
                        {
                            if (inps[j].Point.PointType == PointType.factory)
                            {
                                Node node3 = net[inps[j].Node.Number];
                                if ((inps[j].Point.Number > 0) && (inps[j].Point.Number <= this._startTable.DimV))
                                {
                                    if (((ArcNode) net.NodeArc[node3]).EndArcs.Count == 1)
                                    {
                                        Arc a = ((ArcNode) net.NodeArc[node3]).EndArcs[0];
                                        if (net.GetArcFrom(a) == net.StartNode)
                                        {
                                            if (a.H != this._startTable.GetValAA((uint) (inps[j].Point.Number - 1)))
                                            {
                                                num--;
                                                errKeys.Add(13);
                                                comment = comment + string.Format("Поток через дугу {0}-{1} не верный, должно быть {2}; ", node.Number, inps[j].Node.Number, this._startTable.GetValAA((uint) (inps[j].Point.Number - 1)));
                                            }
                                        }
                                        else
                                        {
                                            num--;
                                            errKeys.Add(12);
                                            comment = comment + string.Format("В вершину-п. производства ({0}) может входить только дуга из стока; ", inps[j].Node.Number);
                                        }
                                    }
                                    else
                                    {
                                        num--;
                                        errKeys.Add(11);
                                        comment = comment + string.Format("В вершину-п. производства ({0}) может входить ровно одна дуга; ", inps[j].Node.Number);
                                    }
                                }
                                else
                                {
                                    num--;
                                }
                            }
                        }
                        for (int k = 0; k < inps.Length; k++)
                        {
                            if (inps[k].Point.PointType == PointType.consumer)
                            {
                                Node node4 = net[inps[k].Node.Number];
                                if ((inps[k].Point.Number > 0) && (inps[k].Point.Number <= this._startTable.DimH))
                                {
                                    if (((ArcNode) net.NodeArc[node4]).StartArcs.Count == 1)
                                    {
                                        Arc arc4 = ((ArcNode) net.NodeArc[node4]).StartArcs[0];
                                        if (net.GetArcTo(arc4) == net.EndNode)
                                        {
                                            if (arc4.H != this._startTable.GetValBB((uint) (inps[k].Point.Number - 1)))
                                            {
                                                num--;
                                                errKeys.Add(0x10);
                                                comment = comment + string.Format("Поток через дугу {0}-{1} не верный, должно быть {2}; ", inps[k].Node.Number, node2.Number, this._startTable.GetValBB((uint) (inps[k].Point.Number - 1)));
                                            }
                                        }
                                        else
                                        {
                                            num--;
                                            errKeys.Add(15);
                                            comment = comment + string.Format("Из вершины-п. потребления ({0}) может выходить только дуга в сток; ", inps[k].Node.Number);
                                        }
                                    }
                                    else
                                    {
                                        num--;
                                        errKeys.Add(14);
                                        comment = comment + string.Format("Из вершины-п. потребления ({0}) может выходить ровно одна дуга; ", inps[k].Node.Number);
                                    }
                                }
                                else
                                {
                                    num--;
                                }
                            }
                        }
                        for (int m = 0; m < inps.Length; m++)
                        {
                            if (inps[m].Point.PointType == PointType.factory)
                            {
                                for (int n = 0; n < inps.Length; n++)
                                {
                                    if (inps[n].Point.PointType == PointType.consumer)
                                    {
                                        bool selection = currTable.GetSelection((uint) (inps[m].Point.Number - 1), (uint) (inps[n].Point.Number - 1));
                                        Node node5 = net[inps[m].Node.Number];
                                        Node node6 = net[inps[n].Node.Number];
                                        bool flag2 = false;
                                        Arc arc5 = net.GetArc(node5.Number, node6.Number);
                                        if (arc5 != null)
                                        {
                                            flag2 = true;
                                        }
                                        if (flag2 == selection)
                                        {
                                            if (flag2 && !arc5.InfH)
                                            {
                                                num--;
                                                errKeys.Add(0x13);
                                                comment = comment + string.Format("Пропускная способность дуги {0}-{1} задана неверно; ", node5.Number, node6.Number);
                                            }
                                        }
                                        else if (flag2 && !selection)
                                        {
                                            num--;
                                            errKeys.Add(0x11);
                                            comment = comment + string.Format("Выделение в таблице и сеть не соответствуют:\r\n\tнайдена \"лишняя\" дуга {0}-{1}; ", node5.Number, node6.Number);
                                        }
                                        else if (selection && !flag2)
                                        {
                                            num--;
                                            errKeys.Add(0x12);
                                            comment = comment + string.Format("Выделение в таблице и сеть не соответствуют:\r\n\tне найдена дуга {0}-{1}; ", node5.Number, node6.Number);
                                        }
                                        else
                                        {
                                            num--;
                                            errKeys.Add(0x12);
                                            comment = comment + string.Format("Выделение в таблице и сеть не соответствуют:\r\n\tп. производства {0}, п. потребления {1}; ", inps[m].Point.Number, inps[n].Point.Number);
                                        }
                                    }
                                }
                            }
                        }
                        return num;
                    }
                    num--;
                    return num;
                }
                num--;
                errKeys.Add(6);
                comment = comment + string.Format("Неверное число п. производства({0}) и п. потребления({1}), должно быть {2} и {3}; ", new object[] { num2, num3, currTable.DimV, currTable.DimH });
                return num;
            }
            num--;
            errKeys.Add(5);
            comment = comment + string.Format("Неверное число вершин в сети ({0}), должно быть {1}; ", net.Nodes.Count, (currTable.DimH + currTable.DimV) + 2);
            return num;
        }

        private ItemNodePoint[] CloneINPS(ItemNodePoint[] inps)
        {
            return this.GetINPSarr(this.GetINPSstr(inps));
        }

        private int FirstTableCheck(HungTable currTable, ArrayList errKeys, ref string comment)
        {
            int num = 0;
            int maxCD = this.GetMaxCD();
            for (uint i = 0; i < this._startTable.DimV; i++)
            {
                if (currTable.GetValAA(i) != this.GetNewValAA(maxCD, i))
                {
                    num--;
                    errKeys.Add(1);
                    comment = comment + string.Format("Неверно задан элемент A[{0}]={1}, должно быть {2}; ", i + 1, currTable.GetValAA(i), this.GetNewValAA(maxCD, i));
                }
                for (uint j = 0; j < this._startTable.DimH; j++)
                {
                    if ((i == 0) && (currTable.GetValBB(j) != 0))
                    {
                        num--;
                        errKeys.Add(2);
                        comment = comment + string.Format("Неверно задан элемент B[{0}]={1}, должно быть {2}; ", j + 1, currTable.GetValBB(j), 0);
                    }
                    if (currTable.GetValCD(i, j) != (maxCD - this._startTable.GetValCD(i, j)))
                    {
                        num--;
                        errKeys.Add(3);
                        comment = comment + string.Format("Неверно задан элемент D[{0}, {1}]={2}, должно быть {3}; ", new object[] { i + 1, j + 1, currTable.GetValCD(i, j), maxCD - this._startTable.GetValCD(i, j) });
                    }
                    if ((this.GetNewValAA(maxCD, i) == (maxCD - this._startTable.GetValCD(i, j))) && !currTable.GetSelection(i, j))
                    {
                        num--;
                        errKeys.Add(4);
                        comment = comment + string.Format("Элемент D[{0}, {1}] должен быть выделен; ", i + 1, j + 1);
                    }
                    if (currTable.GetSelection(i, j) && (this.GetNewValAA(maxCD, i) != (maxCD - this._startTable.GetValCD(i, j))))
                    {
                        num--;
                        errKeys.Add(4);
                        comment = comment + string.Format("Элемент D[{0}, {1}] не должен быть выделен; ", i + 1, j + 1);
                    }
                }
            }
            return num;
        }

        private ItemNodePoint[] GetINPSarr(string s)
        {
            if (s.IndexOf('|') >= 0)
            {
                string[] strArray = s.Split(new char[] { '|' });
                ItemNodePoint[] pointArray = new ItemNodePoint[strArray.Length];
                for (int i = 0; i < pointArray.Length; i++)
                {
                    pointArray[i] = ItemNodePoint.GetObject(strArray[i]);
                }
                return pointArray;
            }
            return null;
        }

        private string GetINPSstr(ItemNodePoint[] inps)
        {
            string str = string.Empty;
            if (inps != null)
            {
                for (int i = 0; i < inps.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str = string.Format("{0}{1}", str, "|");
                    }
                    str = string.Format("{0}{1}", str, inps[i].GetString());
                }
            }
            return str;
        }

        private int GetMaxCD()
        {
            int valCD = -2147483648;
            for (uint i = 0; i < this._startTable.DimV; i++)
            {
                for (uint j = 0; j < this._startTable.DimH; j++)
                {
                    if (this._startTable.GetValCD(i, j) > valCD)
                    {
                        valCD = this._startTable.GetValCD(i, j);
                    }
                }
            }
            return valCD;
        }

        private int GetNewValAA(int maxCD, uint i)
        {
            int num = -2147483648;
            for (uint j = 0; j < this._startTable.DimH; j++)
            {
                if ((maxCD - this._startTable.GetValCD(i, j)) > num)
                {
                    num = maxCD - this._startTable.GetValCD(i, j);
                }
            }
            return num;
        }

        public bool IsOver()
        {
            return this.isOver;
        }

        public ActionResult TestAction(Mephi.K22.LearningSuite.Core.Action act)
        {
            HungTable table2;
            ItemNodePoint[] pointArray2;
            Net net2;
            int num4;
            int num8;
            ActionResult result = new ActionResult();
            ArrayList errKeys = new ArrayList();
            switch (act.ActionType)
            {
                case 4:
                {
                    if (this.methodState != Mephi.K22.LearningSuite.Transport.Hung.State.start)
                    {
                        if (this.methodState != Mephi.K22.LearningSuite.Transport.Hung.State.changeTable)
                        {
                            return result;
                        }
                        table2 = HungTable.GetFromString((string) act.Parameters[0]);
                        ArrayList list3 = (ArrayList) act.Parameters[2];
                        pointArray2 = new ItemNodePoint[list3.Count];
                        net2 = Net.GetFromString((string) act.Parameters[1]);
                        for (int n = 0; n < list3.Count; n++)
                        {
                            pointArray2[n] = ItemNodePoint.GetObject((string) list3[n]);
                        }
                        num4 = 0;
                        for (uint num5 = 0; num5 < this._startTable.DimV; num5++)
                        {
                            for (uint num6 = 0; num6 < this._startTable.DimH; num6++)
                            {
                                if (table2.GetValCD(num5, num6) != this._prevTable.GetValCD(num5, num6))
                                {
                                    num4--;
                                    errKeys.Add(3);
                                    result.Comment = result.Comment + string.Format("Неверно задан элемент D[{0}, {1}]={2}, должно быть {3}; ", new object[] { num5 + 1, num6 + 1, table2.GetValCD(num5, num6), this._prevTable.GetValCD(num5, num6) });
                                }
                            }
                        }
                        int valAA = -2147483648;
                        num8 = 1;
                        bool flag = false;
                        HungTable table3 = this._prevTable.Clone();
                        for (uint num9 = 0; num9 < this._prevTable.DimV; num9++)
                        {
                            if (valAA < this._prevTable.GetValAA(num9))
                            {
                                valAA = this._prevTable.GetValAA(num9);
                            }
                        }
                        while (valAA >= 0)
                        {
                            for (int num10 = 0; num10 < this._prevInps.Length; num10++)
                            {
                                if (((this._prevInps[num10].Point.PointType == PointType.factory) && this._prevNet[this._prevInps[num10].Node.Number].IsMark) && (((this._prevInps[num10].Point.Number - 1) >= 0) && ((this._prevInps[num10].Point.Number - 1) < this._startTable.DimV)))
                                {
                                    table3.SetValAA((uint) (this._prevInps[num10].Point.Number - 1), table3.GetValAA((uint) (this._prevInps[num10].Point.Number - 1)) - 1);
                                }
                                if (((this._prevInps[num10].Point.PointType == PointType.consumer) && this._prevNet[this._prevInps[num10].Node.Number].IsMark) && (((this._prevInps[num10].Point.Number - 1) >= 0) && ((this._prevInps[num10].Point.Number - 1) < this._startTable.DimH)))
                                {
                                    table3.SetValBB((uint) (this._prevInps[num10].Point.Number - 1), table3.GetValBB((uint) (this._prevInps[num10].Point.Number - 1)) + 1);
                                }
                            }
                            for (uint num11 = 0; num11 < table3.DimV; num11++)
                            {
                                for (uint num12 = 0; num12 < table3.DimH; num12++)
                                {
                                    if (((table3.GetValAA(num11) + table3.GetValBB(num12)) == table3.GetValCD(num11, num12)) != table3.GetSelection(num11, num12))
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag)
                                {
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                            num8++;
                            valAA--;
                        }
                        break;
                    }
                    int num = 0;
                    HungTable fromString = HungTable.GetFromString((string) act.Parameters[0]);
                    ArrayList list2 = (ArrayList) act.Parameters[2];
                    ItemNodePoint[] inps = new ItemNodePoint[list2.Count];
                    Net net = Net.GetFromString((string) act.Parameters[1]);
                    for (int m = 0; m < list2.Count; m++)
                    {
                        inps[m] = ItemNodePoint.GetObject((string) list2[m]);
                    }
                    string str = string.Empty;
                    num -= this.FirstTableCheck(fromString, errKeys, ref str);
                    result.Comment = result.Comment + str;
                    string str2 = string.Empty;
                    num -= this.CheckNet(fromString, inps, net, errKeys, ref str2);
                    result.Comment = result.Comment + str2;
                    this._prevTable = fromString.Clone();
                    this._prevInps = this.CloneINPS(inps);
                    if (num == 0)
                    {
                        result.Accuracy = AccuracyType.yes;
                    }
                    else
                    {
                        result.Accuracy = AccuracyType.no;
                    }
                    this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.begin;
                    return result;
                }
                case 5:
                {
                    errKeys = new ArrayList();
                    if (this.methodState != Mephi.K22.LearningSuite.Transport.Hung.State.begin)
                    {
                        if (this.methodState == Mephi.K22.LearningSuite.Transport.Hung.State.change)
                        {
                            result.Accuracy = AccuracyType.yes;
                            int num26 = (int) act.Parameters[0];
                            int num27 = (int) act.Parameters[1];
                            int num28 = (int) act.Parameters[2];
                            int num29 = (int) act.Parameters[3];
                            Node node8 = this._net[this.tempNodeInd];
                            if (node8 != null)
                            {
                                if (node8.IsMark)
                                {
                                    if ((((num27 == node8.Number) && (num26 == node8.Z)) && node8.Plus) || (((num27 == node8.Z) && (num26 == node8.Number)) && !node8.Plus))
                                    {
                                        if ((((num28 - num29) != this.flowChange) || !node8.Plus) && (((num29 - num28) != this.flowChange) || node8.Plus))
                                        {
                                            result.Accuracy = AccuracyType.no;
                                            result.Comment = "неверное изменение потока";
                                            errKeys.Add(0x15);
                                        }
                                    }
                                    else
                                    {
                                        result.Accuracy = AccuracyType.no;
                                        result.Comment = "неверная дуга";
                                        errKeys.Add(0x16);
                                    }
                                    if (node8.Plus)
                                    {
                                        this.tempNodeInd = num26;
                                    }
                                    else
                                    {
                                        this.tempNodeInd = num27;
                                    }
                                }
                                else
                                {
                                    result.Accuracy = AccuracyType.no;
                                    result.Comment = "неверная дуга";
                                    errKeys.Add(0x16);
                                }
                            }
                            else
                            {
                                result.Accuracy = AccuracyType.no;
                                result.Comment = "неверная дуга";
                                errKeys.Add(0x16);
                            }
                            if (num26 == this._net.StartNode.Number)
                            {
                                this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.unmark;
                            }
                            return result;
                        }
                        result.Accuracy = AccuracyType.no;
                        result.Comment = "нельзя менять поток";
                        this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.change;
                        errKeys.Add(0x17);
                        return result;
                    }
                    Arc arc8 = this._net.GetArc((int) act.Parameters[0], (int) act.Parameters[1]);
                    if (!arc8.InfH && (arc8.H < ((int) act.Parameters[2])))
                    {
                        result.Accuracy = AccuracyType.no;
                        result.Comment = "Поток не может быть больше максимальной пропускной способности";
                        errKeys.Add(20);
                        return result;
                    }
                    result.Accuracy = AccuracyType.yes;
                    return result;
                }
                case 6:
                {
                    bool flag2 = true;
                    result.Accuracy = AccuracyType.yes;
                    if (this.methodState == Mephi.K22.LearningSuite.Transport.Hung.State.begin)
                    {
                        int num17 = 0;
                        foreach (Arc arc in ((ArcNode) this._net.NodeArc[this._net.StartNode]).StartArcs)
                        {
                            num17 += arc.F;
                        }
                        foreach (Arc arc2 in ((ArcNode) this._net.NodeArc[this._net.EndNode]).EndArcs)
                        {
                            num17 -= arc2.F;
                        }
                        if (num17 != 0)
                        {
                            flag2 = false;
                        }
                        foreach (Node node in this._net.Nodes)
                        {
                            ArcNode node2 = (ArcNode) this._net.NodeArc[node];
                            if ((node != this._net.StartNode) && (node != this._net.EndNode))
                            {
                                int num18 = 0;
                                foreach (Arc arc3 in node2.StartArcs)
                                {
                                    num18 += arc3.F;
                                }
                                foreach (Arc arc4 in node2.EndArcs)
                                {
                                    num18 -= arc4.F;
                                }
                                if (num18 != 0)
                                {
                                    flag2 = false;
                                }
                            }
                        }
                        this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.mark;
                    }
                    if (this.methodState == Mephi.K22.LearningSuite.Transport.Hung.State.unmark)
                    {
                        int num19 = 0;
                        foreach (Node node3 in this._net.Nodes)
                        {
                            if (node3.IsMark && (this._net.StartNode != node3))
                            {
                                num19++;
                            }
                        }
                        if (num19 == 0)
                        {
                            this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.mark;
                        }
                    }
                    if (this.methodState != Mephi.K22.LearningSuite.Transport.Hung.State.mark)
                    {
                        errKeys.Add(0x1f);
                        result.Accuracy = AccuracyType.no;
                        result.Comment = "Нельзя ставить пометки";
                        this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.mark;
                        return result;
                    }
                    if (!flag2)
                    {
                        errKeys.Add(0x18);
                        result.Accuracy = AccuracyType.no;
                        result.Comment = "Нет баланса потока в сети";
                    }
                    if (result.Comment != string.Empty)
                    {
                        result.Comment = result.Comment + "; ";
                    }
                    int nFrom = (int) act.Parameters[0];
                    bool flag3 = (bool) act.Parameters[1];
                    int num21 = (int) act.Parameters[2];
                    bool flag4 = (bool) act.Parameters[3];
                    bool flag5 = (bool) act.Parameters[4];
                    int num22 = (int) act.Parameters[5];
                    if (!this._net.StartNode.IsMark)
                    {
                        if (this._net.StartNode.Number == nFrom)
                        {
                            if ((!flag3 || flag4) || !flag5)
                            {
                                errKeys.Add(0x1d);
                                result.Accuracy = AccuracyType.no;
                                result.Comment = "Не верно помечен исток (д.б. (-;inf))";
                            }
                        }
                        else
                        {
                            errKeys.Add(30);
                            result.Accuracy = AccuracyType.no;
                            result.Comment = "Первым помечается исток";
                        }
                    }
                    else if (!flag4)
                    {
                        Node node5 = this._net[num21];
                        bool flag6 = false;
                        if (node5 == null)
                        {
                            errKeys.Add(0x1a);
                            result.Accuracy = AccuracyType.no;
                            result.Comment = result.Comment + "пометка вершины определена неверно (Z,+/-)";
                        }
                        else if (!node5.IsMark || node5.IsEmpty)
                        {
                            errKeys.Add(0x1a);
                            result.Accuracy = AccuracyType.no;
                            result.Comment = result.Comment + "пометка вершины определена неверно (Z,+/-)";
                        }
                        else
                        {
                            Arc arc6 = this._net.GetArc(nFrom, node5.Number);
                            if (arc6 == null)
                            {
                                errKeys.Add(0x1a);
                                result.Accuracy = AccuracyType.no;
                                result.Comment = result.Comment + "пометка вершины определена неверно (Z,+/-)";
                            }
                            else if (arc6.F <= 0)
                            {
                                errKeys.Add(0x1c);
                                result.Accuracy = AccuracyType.no;
                                result.Comment = result.Comment + "у дуги F д.б. > 0";
                            }
                            else
                            {
                                foreach (Arc arc7 in ((ArcNode) this._net.NodeArc[node5]).StartArcs)
                                {
                                    if (!this._net.GetArcTo(arc7).IsMark && (arc7.H > arc7.F))
                                    {
                                        flag6 = true;
                                        break;
                                    }
                                }
                                if (flag6)
                                {
                                    errKeys.Add(0x1b);
                                    result.Accuracy = AccuracyType.no;
                                    result.Comment = result.Comment + "Нельзя помечать с -, есть вершины для пометки с +";
                                }
                                else
                                {
                                    int f = -2147483648;
                                    if (arc6.F < node5.E)
                                    {
                                        f = arc6.F;
                                    }
                                    else
                                    {
                                        f = node5.E;
                                    }
                                    if ((num22 != f) || (num22 <= 0))
                                    {
                                        errKeys.Add(0x19);
                                        result.Accuracy = AccuracyType.no;
                                        result.Comment = result.Comment + string.Format("не верно определен E (д.б. {0})", f);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Node node4 = this._net[num21];
                        if (node4 == null)
                        {
                            errKeys.Add(0x1a);
                            result.Accuracy = AccuracyType.no;
                            result.Comment = result.Comment + "пометка вершины определена неверно (Z,+/-)";
                        }
                        else
                        {
                            Arc arc5 = this._net.GetArc(node4.Number, nFrom);
                            if (arc5 == null)
                            {
                                errKeys.Add(0x1a);
                                result.Accuracy = AccuracyType.no;
                                result.Comment = result.Comment + "пометка вершины определена неверно (Z,+/-)";
                            }
                            else
                            {
                                int e = -2147483648;
                                if (node4.Inf)
                                {
                                    e = arc5.H - arc5.F;
                                }
                                else if ((arc5.H - arc5.F) < node4.E)
                                {
                                    e = arc5.H - arc5.F;
                                }
                                else
                                {
                                    e = node4.E;
                                }
                                if ((num22 != e) || (num22 <= 0))
                                {
                                    errKeys.Add(0x19);
                                    result.Accuracy = AccuracyType.no;
                                    result.Comment = result.Comment + string.Format("не верно определен E (д.б. {0})", e);
                                }
                            }
                        }
                    }
                    if (this._net.EndNode.Number == nFrom)
                    {
                        this.tempNodeInd = nFrom;
                        this.flowChange = num22;
                        this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.change;
                    }
                    return result;
                }
                case 7:
                {
                    result.Accuracy = AccuracyType.yes;
                    if (this.methodState != Mephi.K22.LearningSuite.Transport.Hung.State.unmark)
                    {
                        errKeys.Add(0x20);
                        result.Accuracy = AccuracyType.no;
                        result.Comment = "Нельзя удалять пометки";
                        this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.unmark;
                        return result;
                    }
                    int num25 = 0;
                    foreach (Node node7 in this._net.Nodes)
                    {
                        if (node7.IsMark)
                        {
                            num25++;
                        }
                    }
                    if (num25 == 0)
                    {
                        this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.mark;
                    }
                    return result;
                }
                case 8:
                    return result;

                case 9:
                {
                    result.Accuracy = AccuracyType.yes;
                    int num30 = 0;
                    foreach (Arc arc9 in ((ArcNode) this._net.NodeArc[this._net.StartNode]).StartArcs)
                    {
                        num30 += arc9.H - arc9.F;
                    }
                    foreach (Arc arc10 in ((ArcNode) this._net.NodeArc[this._net.EndNode]).EndArcs)
                    {
                        num30 += arc10.H - arc10.F;
                    }
                    if (num30 != 0)
                    {
                        int num31 = 0;
                        foreach (Node node9 in this._net.Nodes)
                        {
                            if (node9.IsMark)
                            {
                                ArcNode node10 = (ArcNode) this._net.NodeArc[node9];
                                foreach (Arc arc11 in node10.StartArcs)
                                {
                                    if ((arc11.F < arc11.H) && !this._net.GetArcTo(arc11).IsMark)
                                    {
                                        num31++;
                                        break;
                                    }
                                }
                                foreach (Arc arc12 in node10.EndArcs)
                                {
                                    if ((arc12.F > 0) && !this._net.GetArcFrom(arc12).IsMark)
                                    {
                                        num31++;
                                        break;
                                    }
                                }
                                continue;
                            }
                            if ((node9 == this._net.StartNode) && !node9.IsMark)
                            {
                                num31++;
                                break;
                            }
                        }
                        if (num31 > 0)
                        {
                            result.Accuracy = AccuracyType.no;
                            result.Comment = "Есть вершины для расставления пометок";
                            errKeys.Add(0x21);
                        }
                    }
                    this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.end;
                    foreach (Arc arc13 in ((ArcNode) this._net.NodeArc[this._net.StartNode]).StartArcs)
                    {
                        if ((arc13.H - arc13.F) != 0)
                        {
                            this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.changeTable;
                            break;
                        }
                    }
                    this._prevNet = this._net.Clone();
                    return result;
                }
                case 10:
                {
                    if (this.methodState != Mephi.K22.LearningSuite.Transport.Hung.State.end)
                    {
                        errKeys.Add(0x24);
                        result.Comment = result.Comment + string.Format("не время для ответа; ", new object[0]);
                        result.Accuracy = AccuracyType.no;
                        return result;
                    }
                    HungTable table4 = HungTable.GetFromString((string) act.Parameters[0]);
                    int num32 = 0;
                    for (uint num33 = 0; num33 < table4.DimV; num33++)
                    {
                        for (uint num34 = 0; num34 < table4.DimH; num34++)
                        {
                            int number = -1;
                            for (int num36 = 0; num36 < this._prevInps.Length; num36++)
                            {
                                if ((this._prevInps[num36].Point.Number == (num33 + 1)) && (this._prevInps[num36].Point.PointType == PointType.factory))
                                {
                                    number = this._prevInps[num36].Node.Number;
                                }
                            }
                            int nTo = -1;
                            for (int num38 = 0; num38 < this._prevInps.Length; num38++)
                            {
                                if ((this._prevInps[num38].Point.Number == (num34 + 1)) && (this._prevInps[num38].Point.PointType == PointType.consumer))
                                {
                                    nTo = this._prevInps[num38].Node.Number;
                                }
                            }
                            if ((number != -1) && (nTo != -1))
                            {
                                Arc arc14 = this._prevNet.GetArc(number, nTo);
                                if (arc14 != null)
                                {
                                    if (arc14.F != table4.GetValCD(num33, num34))
                                    {
                                        num32--;
                                        errKeys.Add(0x23);
                                        result.Comment = result.Comment + string.Format("неверно задан ({0};{1}) элемент таблицы результата = {2}, д.б. {3}; ", new object[] { num33 + 1, num34 + 1, table4.GetValCD(num33, num34), arc14.F });
                                    }
                                }
                                else if (table4.GetValCD(num33, num34) != 0)
                                {
                                    num32--;
                                    errKeys.Add(0x24);
                                    result.Comment = result.Comment + string.Format("элемент таблицы результата ({0};{1}) д.б. равен 0; ", num33 + 1, num34 + 1);
                                }
                            }
                            else
                            {
                                num32--;
                            }
                        }
                    }
                    int num39 = 0;
                    for (uint num40 = 0; num40 < table4.DimV; num40++)
                    {
                        for (uint num41 = 0; num41 < table4.DimH; num41++)
                        {
                            num39 += this._startTable.GetValCD(num40, num41) * table4.GetValCD(num40, num41);
                        }
                    }
                    if (num39 != ((int) act.Parameters[1]))
                    {
                        num32--;
                        errKeys.Add(0x24);
                        result.Comment = result.Comment + string.Format("неверно рассчитана стоимость перевозок {0}, д.б. {1}; ", act.Parameters[1], num39);
                    }
                    this.isOver = true;
                    if (num32 != 0)
                    {
                        result.Accuracy = AccuracyType.no;
                        return result;
                    }
                    result.Accuracy = AccuracyType.yes;
                    return result;
                }
                default:
                    return result;
            }
            for (int i = 0; i < this._prevInps.Length; i++)
            {
                if ((this._prevInps[i].Point.PointType == PointType.factory) && this._prevNet[this._prevInps[i].Node.Number].IsMark)
                {
                    if (((this._prevInps[i].Point.Number - 1) >= 0) && ((this._prevInps[i].Point.Number - 1) < this._startTable.DimV))
                    {
                        if (table2.GetValAA((uint) (this._prevInps[i].Point.Number - 1)) != (this._prevTable.GetValAA((uint) (this._prevInps[i].Point.Number - 1)) - num8))
                        {
                            num4--;
                            errKeys.Add(1);
                            result.Comment = result.Comment + string.Format("Неверно задан элемент A[{0}]={1}, должно быть {2}; ", this._prevInps[i].Point.Number, table2.GetValAA((uint) (this._prevInps[i].Point.Number - 1)), this._prevTable.GetValAA((uint) (this._prevInps[i].Point.Number - 1)) - num8);
                        }
                    }
                    else
                    {
                        num4--;
                        errKeys.Add(1);
                        result.Comment = result.Comment + string.Format("Неверно задан элемент A", new object[0]);
                    }
                }
            }
            for (int j = 0; j < this._prevInps.Length; j++)
            {
                if ((this._prevInps[j].Point.PointType == PointType.consumer) && this._prevNet[this._prevInps[j].Node.Number].IsMark)
                {
                    if (((this._prevInps[j].Point.Number - 1) >= 0) && ((this._prevInps[j].Point.Number - 1) < this._startTable.DimH))
                    {
                        if (table2.GetValBB((uint) (this._prevInps[j].Point.Number - 1)) != (this._prevTable.GetValBB((uint) (this._prevInps[j].Point.Number - 1)) + num8))
                        {
                            num4--;
                            errKeys.Add(2);
                            result.Comment = result.Comment + string.Format("Неверно задан элемент B[{0}]={1}, должно быть {2}; ", this._prevInps[j].Point.Number, table2.GetValBB((uint) (this._prevInps[j].Point.Number - 1)), this._prevTable.GetValBB((uint) (this._prevInps[j].Point.Number - 1)) + num8);
                        }
                    }
                    else
                    {
                        num4--;
                        errKeys.Add(2);
                        result.Comment = result.Comment + string.Format("Неверно задан элемент B", new object[0]);
                    }
                }
            }
            for (uint k = 0; k < this._startTable.DimV; k++)
            {
                for (uint num16 = 0; num16 < this._startTable.DimH; num16++)
                {
                    if ((table2.GetValAA(k) + table2.GetValBB(num16)) == table2.GetValCD(k, num16))
                    {
                        if (!table2.GetSelection(k, num16))
                        {
                            num4--;
                            errKeys.Add(4);
                            result.Comment = result.Comment + string.Format("Элемент D[{0}, {1}] должен быть выделен; ", k + 1, num16 + 1);
                        }
                    }
                    else if (table2.GetSelection(k, num16) && ((table2.GetValAA(k) + table2.GetValBB(num16)) != table2.GetValCD(k, num16)))
                    {
                        num4--;
                        errKeys.Add(4);
                        result.Comment = result.Comment + string.Format("Элемент D[{0}, {1}] не должен быть выделен; ", k + 1, num16 + 1);
                    }
                }
            }
            string comment = string.Empty;
            num4 -= this.CheckNet(table2, pointArray2, net2, errKeys, ref comment);
            result.Comment = result.Comment + comment;
            this._prevTable = table2.Clone();
            this._prevInps = this.CloneINPS(pointArray2);
            if (num4 == 0)
            {
                result.Accuracy = AccuracyType.yes;
            }
            else
            {
                result.Accuracy = AccuracyType.no;
            }
            this.methodState = Mephi.K22.LearningSuite.Transport.Hung.State.begin;
            return result;
        }

        public object[] InnerState
        {
            get
            {
                return new object[] { this.methodState, this._prevTable.GetString(), this.tempNodeInd, ((this._prevNet == null) ? string.Empty : this._prevNet.GetString()), this.GetINPSstr(this._prevInps), this.isOver };
            }
            set
            {
                object[] objArray = value;
                this.methodState = (Mephi.K22.LearningSuite.Transport.Hung.State) objArray[0];
                this._prevTable = HungTable.GetFromString((string) objArray[1]);
                this.tempNodeInd = (int) objArray[2];
                this._prevNet = (((string) objArray[3]) == string.Empty) ? null : Net.GetFromString((string) objArray[3]);
                this._prevInps = this.GetINPSarr((string) objArray[4]);
                this.isOver = (bool) objArray[5];
            }
        }
    }
}

