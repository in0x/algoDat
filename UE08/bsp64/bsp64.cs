/* 141061024, fhs37246
   * Philipp Welsch
   * ue08 bsp64    */

using System;
// you can also use other imports, for example:
using System.Collections.Generic;

// you can use Console.WriteLine for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class MainClass {
    Solution test = new Solution();
    int[] A = {4,5,3,6,2};
    int[] B = {1,}
}

class Solution {
    public int solution(int[] A, int[] B) {
        if (A.Length == 0 || B.Length == 0)
            return 0;  
        List<int> well = new List<int>(A.Length + B.Length);
        int disks = 0;
        for (int i = 0; i < well.Capacity; i++)
            well.Add(0);
        for (int i = 0; i < A.Length; i++) 
            well[i] = A[i];
            
        for (int b = 0; b < B.Length -1; b++) {
            for (int a = 0; a <= well.Count; a++) {
                if (B[b].CompareTo(well[a]) <= 0) {
                    if (a == well.Count) {
                        well.Insert(well.Count+1, B[b]);  
                        disks++;
                        break;
                    }   
                } else if (a == 0)
                    return disks;
                else {
                    disks++;
                    well.Insert(a - 1, B[b]);
                    break;
                }
            }
        }
        return disks;
    }
}