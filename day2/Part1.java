package day2;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Part1{
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
            for(int i = 0; i<value.length;i++){
                arr.add(Integer.valueOf(value[i]));
            }
            arr1.add(arr);
        }
        myReader.close();
        } catch (FileNotFoundException e) {
        }
        

        int counter = arr1.size();
        boolean rises;

        for(ArrayList<Integer> a : arr1){
            if(a.get(0)-a.get(1)>0){
                rises = false;
            }else{
                rises = true;
            }
            for(int i = 1; i<a.size();i++){
                if(Math.abs(a.get(i)-a.get(i-1))>3||Math.abs(a.get(i)-a.get(i-1))==0){
                    counter--;
                    break;
                }
                if(rises == false && (a.get(i)-a.get(i-1))>0){
                    counter--;
                    break;
                }
                if(rises == true && (a.get(i)-a.get(i-1))<0){
                    counter--;
                    break;
                }
            }
        }
        System.out.println(counter);
        

    }
    
        
}





