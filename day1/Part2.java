package day1;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Part2{
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
        int[] tab1 = new int[1000];
        int[] tab2 = new int[1000];
        for(int i = 0; i<arr1.size();i++){
            tab1[i] = arr1.get(i);
            tab2[i] = arr2.get(i);
        }

        long wynik = 0;
        int counter = 0;
        for(int i = 0; i<tab1.length;i++){
            counter = 0;
           for(int j = 0; j<tab1.length;j++){
            if(tab1[i]==tab2[j])counter++;
           }
           wynik +=(tab1[i]*counter);
        }
        System.out.println(wynik);

    }
        
}





