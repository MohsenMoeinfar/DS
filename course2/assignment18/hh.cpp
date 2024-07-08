#include <iostream>
#include <vector>
#include<string>
using namespace std;

long BinarySearch(vector<long>& inp, long key) {
    long low = 0;
    long high = inp.size() - 1;
    while (high >= low) {
        long mid = (low + high) / 2;
        if (key == inp[mid]) {
            return mid;
        }
        else if (key < inp[mid]) {
            high = mid - 1;
        }
        else {
            low = mid + 1;
        }
    }
    return -1;
}

int main() {
    long L1;
    cin >> L1;
    vector<long> inp1(L1);
    for (long i = 0; i < L1; i++) {
        cin >> inp1[i];
    }

    long L2;
    cin >> L2;
    vector<long> inp2(L2);
    for (long i = 0; i < L2; i++) {
        cin >> inp2[i];
    }

    string ans;
    for (long i = 0; i < L2; i++) {
        long result = BinarySearch(inp1, inp2[i]);
        ans += to_string(result) + " ";
    }

    cout << ans << endl;

    return 0;
}