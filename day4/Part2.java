package day4;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
@SuppressWarnings("ConvertToTryWithResources")
public class Part2 {

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

    
    int counter = 0;
    for (int i = 0; i < input.size(); i++) {
        for (int j = 0; j < input.get(i).size(); j++) { 
            if(input.get(i).get(j)=='A'){
                try {  
                    //MM                  
                    if(input.get(i-1).get(j-1)=='M'&&input.get(i+1).get(j+1)=='S'&&input.get(i-1).get(j+1)=='M'&&input.get(i+1).get(j-1)=='S')counter++;
                } catch (Exception e) {
                }
                try {  
                    //MS                  
                    if(input.get(i-1).get(j-1)=='M'&&input.get(i+1).get(j+1)=='S'&&input.get(i-1).get(j+1)=='S'&&input.get(i+1).get(j-1)=='M')counter++;
                } catch (Exception e) {
                }
                try {  
                    //SM                  
                    if(input.get(i-1).get(j-1)=='S'&&input.get(i+1).get(j+1)=='M'&&input.get(i-1).get(j+1)=='M'&&input.get(i+1).get(j-1)=='S')counter++;
                } catch (Exception e) {
                }
                try {  
                    //SS                  
                    if(input.get(i-1).get(j-1)=='S'&&input.get(i+1).get(j+1)=='M'&&input.get(i-1).get(j+1)=='S'&&input.get(i+1).get(j-1)=='M')counter++;
                } catch (Exception e) {
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