package day5;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
@SuppressWarnings("ConvertToTryWithResources")
public class Part1 {

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


    for (int i : rules.keySet()) {
        System.out.println("Klucz: "+i+" Values: ");
        for(int j : rules.get(i)){
            System.out.print(j+",");
        }
        System.out.println("");
    }
    int wynik = 0;
    boolean isGud = true;
    for(ArrayList<Integer> a :input){
        isGud = true;
        for(int i = 0; i<a.size();i++){
            for(int j = 0; j<i;j++){
                try {
                    if(rules.get(a.get(i)).contains(a.get(j))){
                        isGud = false;
                        break;
                    }                    
                } catch (Exception e) {
                }                
            }
        }
        if(isGud){
            System.out.println(a.get((a.size()-1)/2));
            wynik+=a.get((a.size()-1)/2);
        }
    }
    System.out.println(wynik);
    



}

}
