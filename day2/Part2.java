package day2;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Objects;
import java.util.Scanner;
//609<x<636
public class Part2{
    @SuppressWarnings("ConvertToTryWithResources")
    public static void main(String[] args) {
        ArrayList<ArrayList<Integer>> arr1 = new ArrayList<>();
        String regex = "[\\s+]";
    try {
        File myObj = new File("day2\\input.txt");
        Scanner myReader = new Scanner(myObj);
        while (myReader.hasNextLine()) {
            String data = myReader.nextLine();
            
            String[] value = data.split(regex);
            ArrayList<Integer> arr = new ArrayList<>();
            for (String value1 : value) {
                arr.add(Integer.valueOf(value1));
            }
            arr1.add(arr);
        }
        myReader.close();
        } catch (FileNotFoundException e) {
        }
        

        int counter = 0;


        for(ArrayList<Integer> a:arr1){
            if(isSafe(a)){
                counter++;
            }else{
                for(int i=0; i<a.size(); i++){
                    ArrayList<Integer> b = new ArrayList<Integer>();
                    for(int c:a){
                        b.add(c);
                    }
                    b.remove(i);
                    if(isSafe(b)){
                        counter++;
                        break;
                    }
                }
                System.out.println("");
            }
        }

        System.out.println(counter);
         
        

    }

    public static boolean isSafe(ArrayList<Integer> a){
        boolean rises = a.get(0)<a.get(1);
            
            for(int i = 0; i<a.size()-1;i++){
                if(Math.abs(a.get(i)-a.get(i+1))>3){
                    return false;
                }
                if(Objects.equals(a.get(i+1), a.get(i))){

                    return false;
                }
                if(rises == false && (a.get(i+1)>a.get(i))){
                    return false;
                }
                if(rises == true && (a.get(i+1)<a.get(i))){
                    return false;
                }
            }
        
        return true;
    }
    
        
}





