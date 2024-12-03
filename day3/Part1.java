package day3;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Part1{
    @SuppressWarnings("ConvertToTryWithResources")
    public static void main(String[] args) {
        
        String input = "";
        try 
        {
            File myObj = new File("day3\\input.txt");
            Scanner myReader = new Scanner(myObj);
            while (myReader.hasNextLine()) {
                input += myReader.nextLine();            
            }
            myReader.close();
        } 
        catch (FileNotFoundException e) {
        }
        String regex = "mul[(]\\d+[,]\\d+[)]";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(input);
        ArrayList<String> arr = new ArrayList<>();
        while (matcher.find()) {
            arr.add(input.substring(matcher.start(),matcher.end()));
        } 

        regex = "\\d+";
        pattern = Pattern.compile(regex);
        int e;
        int f;
        int wynik = 0;
        for(String a:arr){
            matcher = pattern.matcher(a);
            matcher.find();
            e = Integer.parseInt(a.substring(matcher.start(),matcher.end()));
            matcher.find();
            f = Integer.parseInt(a.substring(matcher.start(),matcher.end()));
            wynik+=e*f;
        }
        System.out.println(wynik);
    
    }   
}





