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

    
    int counter = 0;
    for (int i = 0; i < input.size(); i++) {
        for (int j = 0; j < input.get(i).size(); j++) { 
            if(input.get(i).get(j)=='X'){
                try {  
                    //U                  
                    if(input.get(i-1).get(j)=='M'&&input.get(i-2).get(j)=='A'&&input.get(i-3).get(j)=='S')counter++;
                } catch (Exception e) {
                }
                try { 
                    //UR                  
                    if(input.get(i-1).get(j+1)=='M'&&input.get(i-2).get(j+2)=='A'&&input.get(i-3).get(j+3)=='S')counter++;
                } catch (Exception e) {
                }
                try { 
                    //R                  
                    if(input.get(i).get(j+1)=='M'&&input.get(i).get(j+2)=='A'&&input.get(i).get(j+3)=='S')counter++;
                } catch (Exception e) {
                }
                    try { 
                    //DR                  
                    if(input.get(i+1).get(j+1)=='M'&&input.get(i+2).get(j+2)=='A'&&input.get(i+3).get(j+3)=='S')counter++;
                } catch (Exception e) {
                }
                    try { 
                    //D                  
                    if(input.get(i+1).get(j)=='M'&&input.get(i+2).get(j)=='A'&&input.get(i+3).get(j)=='S')counter++;
                } catch (Exception e) {
                }
                    try { 
                    //DL                  
                    if(input.get(i+1).get(j-1)=='M'&&input.get(i+2).get(j-2)=='A'&&input.get(i+3).get(j-3)=='S')counter++;
                } catch (Exception e) {
                }
                    try { 
                    //L                  
                    if(input.get(i).get(j-1)=='M'&&input.get(i).get(j-2)=='A'&&input.get(i).get(j-3)=='S')counter++;
                } catch (Exception e) {
                }
                    try { 
                    //UL                  
                    if(input.get(i-1).get(j-1)=='M'&&input.get(i-2).get(j-2)=='A'&&input.get(i-3).get(j-3)=='S')counter++;
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