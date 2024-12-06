package day5;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
@SuppressWarnings("ConvertToTryWithResources")
public class Part2 {

public static void main(String[] args) {

    HashMap<Integer, ArrayList<Integer>> rules = new HashMap<>();

    ArrayList<ArrayList<Integer>> input = new ArrayList<>();

try {
    File myObj = new File("day5\\input.txt");


    Scanner myReader = new Scanner(myObj);
    while (myReader.hasNextLine()) {
        String data = myReader.nextLine();
        if(data.equals(""))break;
        String[] arr = data.split("[|]");
        rules.computeIfAbsent(Integer.valueOf(arr[0]), k -> new ArrayList<>()).add(Integer.valueOf(arr[1]));
    }
    while (myReader.hasNextLine()) {
        String data = myReader.nextLine();
        if(data.equals(""))break;
        String[] arr = data.split("[,]");
        ArrayList<Integer> b = new ArrayList<>();
        for(String a:arr){
            b.add(Integer.valueOf(a));
        }
        input.add(b);
    }
    myReader.close();
    } catch (FileNotFoundException e) {
    }



    int wynik = 0;
    for(ArrayList<Integer> a :input){
        if(!isGut(a, rules)){
            for(int i = 0; i<a.size();i++){
                int spot = i;
                while(!isGut(a, rules, i)){
                    int tmp = a.get(spot);
                    a.set(spot, a.get(spot-1));
                    a.set(spot-1, tmp);
                    spot--;
                }
            }
            wynik+=a.get((a.size()-1)/2);
        }
    }


    System.out.println(wynik);
}

public static boolean isGut(ArrayList<Integer> a, HashMap<Integer, ArrayList<Integer>> rules){
    for(int i = 0; i<a.size();i++){
        for(int j = 0; j<i;j++){
            try {
                if(rules.get(a.get(i)).contains(a.get(j))){
                    return false;
                }                    
            } catch (Exception e) {
            }                
        }
    }
    return true;
}

public static boolean isGut(ArrayList<Integer> a, HashMap<Integer, ArrayList<Integer>> rules,int l){
    for(int i = 0; i<l+1;i++){
        for(int j = 0; j<i;j++){
            try {
                if(rules.get(a.get(i)).contains(a.get(j))){
                    return false;
                }                    
            } catch (Exception e) {
            }                
        }
    }
    return true;
}

}
