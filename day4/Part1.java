package day4;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
@SuppressWarnings("ConvertToTryWithResources")
public class Part1 {

public static void main(String[] args) {
    ArrayList<ArrayList<Character>> input = new ArrayList<>();    
try {
    File myObj = new File("day4\\input.txt");
    Scanner myReader = new Scanner(myObj);
    while (myReader.hasNextLine()) {
        String data = myReader.nextLine();
        ArrayList<Character> arr = new ArrayList<>();   
        for (char a : data.toCharArray()) {
            arr.add(a);
        }
        input.add(arr);
    }
    myReader.close();
    } catch (FileNotFoundException e) {
    }

    int[] dr = {-1,0,1};
    int[] dc = {-1,0,1};
    int counter = 0;
    for (int i = 0; i < input.size(); i++) {
        for (int j = 0; j < input.get(i).size(); j++) { 
            if(input.get(i).get(j)=='X'){
                for(int r:dr){
                    for(int c:dc){
                        try {                                            
                            if(input.get(i+1*r).get(j+1*c)=='M'&&input.get(i+2*r).get(j+2*c)=='A'&&input.get(i+3*r).get(j+3*c)=='S')counter++;
                        } catch (Exception e) {
                        }
                    }
                }                  
            }
        }
    }
    
    System.out.println(counter);



}



    
}


// for (int i = 0; i < input.size(); i++) {
    //     for (int j = 0; j < input.get(i).size(); j++) { 
    //         if(i<2||j<2||i>input.size()-3||j>input.get(i).size()-3){
    //             input.get(i).set(j, '.');
    //         }
    //     }
    // }