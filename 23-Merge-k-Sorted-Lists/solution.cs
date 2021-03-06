/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists == null || lists.Count() == 0){
            return null;
        }
        return MergeKLists(lists, 0, lists.Count()-1);
    }
    
    private ListNode MergeKLists(ListNode[] lists, int low, int high){
        if(low == high){
            return lists[low];
        }
        if(low + 1 == high){
            return MergeTwoLists(lists[low], lists[high]);
        }
        int mid = low + (high - low)/2;
        return MergeTwoLists(MergeKLists(lists, low, mid), MergeKLists(lists, mid+1, high));
    }
    
    private ListNode MergeTwoLists(ListNode l1, ListNode l2){
        if(l1 == null){
            return l2;
        }
        if(l2 == null){
            return l1;
        }
        ListNode result = l1.val > l2.val ? l2 : l1;
        ListNode cur = result;
        ListNode ins = cur == l1 ? l2 : l1;
        while(cur.next != null && ins != null){
            if(ins.val >= cur.val && ins.val <= cur.next.val){
                var next = ins.next;
                ins.next = cur.next;
                cur.next = ins;
                ins = next;
            }
            cur = cur.next;
        }
        if(cur.next == null){
            cur.next = ins;
        }
        return result;
    }
}