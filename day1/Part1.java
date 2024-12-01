package day1;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Part1{
    @SuppressWarnings("ConvertToTryWithResources")
    public static void main(String[] args) {
        ArrayList<Integer> arr1 = new ArrayList<>();
        ArrayList<Integer> arr2 = new ArrayList<>();
        String regex = "[,\\.\\s]";
    try {
        File myObj = new File("day1\\input.txt");
        Scanner myReader = new Scanner(myObj);
        while (myReader.hasNextLine()) {
            String data = myReader.nextLine();
            String[] myArray = data.split(regex);
            arr1.add(Integer.valueOf(myArray[0]));
            arr2.add(Integer.valueOf(myArray[3]));
        }
        myReader.close();
        } catch (FileNotFoundException e) {
        }

        arr1 = SArrayListort(arr1);
        arr2 = SArrayListort(arr2);
        int wynik = 0;
        for(int i = 0; i<arr1.size();i++){
            wynik+= Math.abs(arr1.get(i)-arr2.get(i));
        }
        System.out.println(wynik);

    }
    public static ArrayList<Integer> SArrayListort(ArrayList<Integer> a){
        for(int i = 0; i<a.size();i++){
            for(int j = i; j<a.size(); j++){
             if(a.get(i)>a.get(j)){
                int tmp = a.get(i);
                a.set(i, a.get(j));
                a.set(j, tmp);
             }   
            }
        }


        return a;
    }
        
}





