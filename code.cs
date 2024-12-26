public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;

        int[] freq = new int[26];
        int[] windFreq = new int[26];

        // Populate freq array with frequencies of characters in s1
        foreach (char c in s1) {
            freq[c - 'a']++;
        }

        // Sliding window
        for (int i = 0; i < s2.Length; i++) {
            windFreq[s2[i] - 'a']++;

            // if i >= s1.Length i.e. the window is already completed, now remove the leftmost character from the window
            if (i >= s1.Length) {
                // subtracting it's frequency as it is not in the current window
                windFreq[s2[i - s1.Length] - 'a']--;
            }

            // Check if the two frequency arrays match
            if (AreArraysEqual(freq, windFreq)) {
                return true;
            }
        }

        return false;
    }

    private bool AreArraysEqual(int[] arr1, int[] arr2) {
        for (int i = 0; i < 26; i++) {
            if (arr1[i] != arr2[i]) return false;
        }
        return true;
    }
}
